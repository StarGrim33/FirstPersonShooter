using DG.Tweening;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Shotgun _shotgun;
    [SerializeField] private Camera _camera;

    private void OnEnable()
    {
        _shotgun.Shooting += Shooting;
    }

    private void OnDisable()
    {
        _shotgun.Shooting -= Shooting;
    }

    private void Shooting()
    {
        _camera.transform.DOShakePosition(0.15f, 0.5f, 7, 90f, false, true, ShakeRandomnessMode.Harmonic).SetEase(Ease.InOutBounce);
    }
}
