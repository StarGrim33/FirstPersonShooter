using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private IInput _input;
    private Player _config;
    private float _speed;

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
    }

    private void Update()
    {

        if (_characterController.isGrounded)
        {
            _characterController.Move(_input.GetDirection() * _speed * Time.deltaTime +Vector3.down);
        }
        else
        {
            _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);
        }
    }

    public void Jump()
    {

    }
}
