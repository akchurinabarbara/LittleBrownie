using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//передвижение домовенка
public class BrownieMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private SkeletonAnimation _skeletonAnimation;
    [SerializeField]
    private float _idleDelay = 15.0f;

    private List<string> _idleAnimations = new List<string> 
    {
        "idle",
        "jump",
        "levitate",
        "think",
        "wait",
        "wait2"
    };

    private List<string> _moveAnimations = new List<string>
    {
        "run_left",
        "run_right"
    };

    private Vector2 _nextTargetPosition;
    private Coroutine _moveCoroutine;
    private Coroutine _randomIdleAnimationCoroutine;
    private bool _isOutCameraMove = false;        

    private CameraMovement _mainCameraMovementController;

    private IEnumerator Move(Vector3 target)
    {
        _skeletonAnimation.AnimationState.ClearTrack(0);
        target.z = transform.position.z;

        //¬ыбираем анимацию движени€ в сторону
        if ((transform.position.x - target.x > 0))
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, _moveAnimations[0], true);
        }
        else
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, _moveAnimations[1], true);
        }

        //ƒвижемс€, пока не достигнем цели
        while (Vector3.Distance(transform.position, target) > 0.001f)
        {
            var step = _speed * Time.deltaTime;            

            transform.position = Vector3.MoveTowards(transform.position, target, step);            

            yield return new WaitForEndOfFrame();
        }

        StartPlayRandomIdle();
    }

    private void StartPlayRandomIdle()
    {
        _skeletonAnimation.AnimationState.SetAnimation(0, _idleAnimations[0], true);

        StopPlayRandomIdle();
        _randomIdleAnimationCoroutine = StartCoroutine(PlayRandomIdle());
    }

    private void StopPlayRandomIdle()
    {
        if (_randomIdleAnimationCoroutine != null)
        {
            StopCoroutine(_randomIdleAnimationCoroutine);
        }
    }

    private IEnumerator PlayRandomIdle()
    {
        //ранжомна€ анимаци€
        while (true)
        {
            yield return new WaitForSeconds(_idleDelay);
            int randomAnimationIndex = Random.Range(0, _idleAnimations.Count);
            _skeletonAnimation.AnimationState.SetAnimation(0, _idleAnimations[randomAnimationIndex], false);
            _skeletonAnimation.AnimationState.AddAnimation(0, _idleAnimations[0], true, 0.0f);
        }        
    }
 

    private void StartMove(Vector2 target)
    {
        StopPlayRandomIdle();

        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);

            _skeletonAnimation.AnimationState.SetAnimation(0, _idleAnimations[0], true);
        }

        _moveCoroutine = StartCoroutine(Move(target));
    }        

    private void Awake()
    {
        _mainCameraMovementController = Camera.main.GetComponent<CameraMovement>();
    }

    private void Update()
    {
        //не выполн€ть код, если нажатие происходит по интфейсу
        if (EventSystem.current.IsPointerOverGameObject()) { return; }

        //”становить цель по курсору
        if (Input.GetMouseButtonDown(0))
        {
            _nextTargetPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
        }

        //≈сли камера не двигалась и домовенок в ее пределах - двигатьс€ к указанной точке
        else if (Input.GetMouseButtonUp(0) && !_mainCameraMovementController.IsCameraMove)
        {
            StartMove(_nextTargetPosition);
        }

        else if(_mainCameraMovementController.IsCameraMove && _isOutCameraMove)
        {
            StartMove(new Vector2(Camera.main.transform.position.x, transform.position.y));
        }
    }

    private void Start()
    {
        StartPlayRandomIdle();
    }

    private void OnBecameInvisible()
    {
        _isOutCameraMove = true;
    }

    private void OnBecameVisible()
    {
        _isOutCameraMove = false;
    }
}