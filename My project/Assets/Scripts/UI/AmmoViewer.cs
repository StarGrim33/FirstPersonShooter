using TMPro;
using UnityEngine;

public class AmmoViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Shotgun _shotgun;

    private void OnEnable()
    {
        _shotgun.AmmoChanged += OnAmmoChanged;
    }

    private void OnAmmoChanged(int value)
    {
        _text.text = value.ToString() + '/' + _shotgun.MaxAmmo.ToString();
    }

    private void OnDisable()
    {
        _shotgun.AmmoChanged -= OnAmmoChanged;
    }

    private void Start()
    {
        _text.text = _shotgun.CurrentAmmo.ToString() + '/' + _shotgun.MaxAmmo.ToString();
    }
}
