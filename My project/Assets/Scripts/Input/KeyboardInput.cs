using UnityEngine;
using Zenject;

public class KeyboardInput : IInput, ITickable
{
    private Vector3 _moveDirection;

    public Vector3 GetDirection()
    {
        return _moveDirection;
    }

    public void ReadInput()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    public void Tick()
    {
        ReadInput();
    }
}
