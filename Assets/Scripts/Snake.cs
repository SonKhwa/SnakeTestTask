using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Snake : MonoBehaviour
{ 
    private float _speed;
    private SnakeInfo _snakeInfo;

    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    public void Init(float speed, SnakeInfo snakeInfo)
    {
        _speed = speed;
        _snakeInfo = snakeInfo;
    }

    public void CreateHead()
    {
        var newBodyPart = Instantiate(_snakeInfo.Head, _transform);
        newBodyPart.GetComponent<Transform>().localPosition = Vector3.zero;
    }

    public void CreateBodyPart()
    {
        var newBodyPart = Instantiate(_snakeInfo.BodyPart);
        Vector3 newPosition = new Vector3(0, 0, -0.5f);
        Quaternion newRotation = Quaternion.identity;

        if (_transform.childCount > 0)
        {
            var lastBodyPart = _transform.GetChild(_transform.childCount - 1);
            newPosition = lastBodyPart.localPosition - new Vector3(0, 0, 0.5f);
            newRotation = lastBodyPart.localRotation;
        }

        newBodyPart.GetComponent<Transform>().SetParent(_transform);
        newBodyPart.GetComponent<Transform>().SetLocalPositionAndRotation(newPosition, newRotation);
    }

    public void Move(float verticalAxisValue, float horizontalAxisValue)
    {
        _rigidbody.velocity =
            new Vector3(horizontalAxisValue * _speed, _rigidbody.velocity.y, verticalAxisValue * _speed);

        if (horizontalAxisValue != 0 || verticalAxisValue != 0)
        {
            _transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }
}
