using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _horizontalFloatSensetivity;
    [SerializeField] private float _verticalFloatSensetivity;

    private CharacterController _characterController;
    private Transform _transform;
    private IInput _input;
    private float _verticalMinAngle = -89f;
    private float _verticalMaxAngle = 89f;

    [Header("Config")]
    private Vector3 _verticalVelocity;
    private Player _config;
    private float _speed;
    private float _strafeSpeed;
    private float _cameraAngle = 0;
    private float _jumpForce;
    private float _jumpCooldown;
    private float _lastJumpTime;

    [Inject]
    private void Construct(IInput input)
    {
        _input = input;
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _config = GetComponent<Player>();
        _speed = _config.Config.Speed;
        _jumpForce = _config.Config.JumpSpeed;
        _jumpCooldown = _config.Config.JumpCooldown;
        _strafeSpeed = _config.Config.StrafeSpeed;
        _cameraAngle = _cameraTransform.localEulerAngles.x;
        _transform = transform;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        _cameraAngle -= Input.GetAxis(Constants.MouseY) * _verticalFloatSensetivity;
        _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
        _cameraTransform.localEulerAngles = Vector3.right * _cameraAngle;
        _transform.Rotate(_horizontalFloatSensetivity * Input.GetAxis(Constants.MouseX) * Vector3.up);
    }

    private void Move()
    {
        Vector3 forward = Vector3.ProjectOnPlane(_cameraTransform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;
        Vector3 xDirection = _input.GetHorizontalDirection();
        Vector3 yDirection = _input.GetVerticalDirection();

        if (_characterController.isGrounded)
        {
            _verticalVelocity = Vector3.zero;

            Vector3 direction = _speed * yDirection.z * forward + _strafeSpeed * xDirection.x * right;

            if (Input.GetKeyDown(KeyCode.Space) && CanJump())
            {
                _verticalVelocity = Vector3.up * _jumpForce;
                _lastJumpTime = Time.time;
            }

            direction *= Time.deltaTime;
            _characterController.Move(direction);
        }
        else
        {
            _verticalVelocity += Physics.gravity * Time.deltaTime;
            Vector3 verticalMovement = _verticalVelocity * Time.deltaTime;
            Vector3 direction = _speed * yDirection.z * forward + _strafeSpeed * xDirection.x * right;
            direction *= Time.deltaTime;
            Vector3 movement = verticalMovement + direction;

            _characterController.Move(movement);
        }
    }

    private bool CanJump()
    {
        return Time.time - _lastJumpTime >= _jumpCooldown && _characterController.isGrounded;
    }
}
