using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float _rightBorder = 0;
    [SerializeField]
    private float _leftBorder = 0;

    private Camera _camera;

    private Vector2 _startMousePosition;
    private bool _isCameraMove = false;

    public bool IsCameraMove { get { return _isCameraMove; } }

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            _startMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            _isCameraMove = false;
        }

        else if (Input.GetMouseButton(0))
        {
            float deltaX = _startMousePosition.x - _camera.ScreenToWorldPoint(Input.mousePosition).x;

            if (!deltaX.Equals(0))
            {
                _isCameraMove = true;
                float  newX = Mathf.Clamp(transform.position.x + deltaX, _leftBorder, _rightBorder);
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
        } 
    }
}
