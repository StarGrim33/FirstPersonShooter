using UnityEngine;
using Zenject;

public class KeyboardInput : IInput, ITickable
{
    private Vector3 _xDirection;

    private Vector3 _yDirection;

    public Vector3 GetHorizontalDirection() => _xDirection;

    public Vector3 GetVerticalDirection() => _yDirection;

    public void ReadInput()
    {
        _xDirection = new Vector3(Input.GetAxis(Constants.Horizontal), 0, 0);
        _yDirection = new Vector3(0, 0, Input.GetAxis(Constants.Vertical));
    }

    public void Tick()
    {
        ReadInput();
    }
}
