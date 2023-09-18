
using UnityEngine;

public interface IInput
{
    void ReadInput();

    Vector3 GetHorizontalDirection();

    Vector3 GetVerticalDirection();
}
