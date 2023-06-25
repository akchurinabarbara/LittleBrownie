using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

//������������ ���������
public class BrownieMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Vector2 _nextTargetPosition;
    private Coroutine _moveCoroutine;
    private bool _isOutCameraMove = false;

    private CameraMovement _mainCameraMovementController;

    private IEnumerator Move(Vector3 target)
    {
        target.z = transform.position.z;

        //��������, ���� �� ��������� ����
        while (Vector3.Distance(transform.position, target) > 0.001f)
        {
            var step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            yield return new WaitForEndOfFrame();
        }
    }

    private void StartMove(Vector2 target)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }

        _moveCoroutine = StartCoroutine(Move(target));
    }        

    private void Awake()
    {
        _mainCameraMovementController = Camera.main.GetComponent<CameraMovement>();
    }

    private void Update()
    {
        //�� ��������� ���, ���� ������� ���������� �� ��������
        if (EventSystem.current.IsPointerOverGameObject()) { return; }

        //���������� ���� �� �������
        if (Input.GetMouseButtonDown(0))
        {
            _nextTargetPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
        }

        //���� ������ �� ��������� � ��������� � �� �������� - ��������� � ��������� �����
        else if (Input.GetMouseButtonUp(0) && !_mainCameraMovementController.IsCameraMove)
        {
            StartMove(_nextTargetPosition);
        }

        else if(_mainCameraMovementController.IsCameraMove && _isOutCameraMove)
        {
            StartMove(new Vector2(Camera.main.transform.position.x, transform.position.y));
        }
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