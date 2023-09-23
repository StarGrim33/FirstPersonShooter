using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Sway settings")]
    [SerializeField] private float _smooth;
    [SerializeField] private float _swayMultiplier;

    private void Update()
    {
        float mouseX = Input.GetAxisRaw(Constants.MouseX) * _swayMultiplier;
        float mouseY = Input.GetAxisRaw(Constants.MouseY) * _swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion targetRotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, _smooth * Time.deltaTime);
    }
}
