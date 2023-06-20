using System.Collections;
using UnityEngine;

public class BrownieMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Vector2 _targetPosition;
    private Coroutine _moveCoroutine;

    private CameraMovement _mainCameraMovementController;

    private IEnumerator BrownieMove(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.001f)
        {
            var step = _speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
            yield return new WaitForEndOfFrame();
        }
    }

    private void StartMove(Vector2 target)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }

        _moveCoroutine = StartCoroutine(BrownieMove(target));
    }

    private void Awake()
    {
        _mainCameraMovementController = Camera.main.GetComponent<CameraMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //Домовенок не может двигаться, если камера в движении
        if (Input.GetMouseButtonUp(0) && !_mainCameraMovementController.IsCameraMove)
        {
            StartMove(new Vector2(_targetPosition.x, transform.position.y));
        }
    }

    private void OnBecameInvisible()
    {
        //Если домовенок находится за пределами видимости камеры - идет к новому расположени камеры
        StartMove(new Vector2(Camera.main.transform.position.x, transform.position.y));
    }

}

