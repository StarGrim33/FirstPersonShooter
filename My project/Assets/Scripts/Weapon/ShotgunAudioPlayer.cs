using System.Collections;
using UnityEngine;
using Zenject;

public class ShotgunAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _shotSound;
    [SerializeField] private AudioClip _reloadSound;
    [SerializeField] private ParticleSystem _shotEffect;
    [SerializeField] private GameObject _lightSource;

    private Shotgun _shotgun;

    [Inject]
    private void Construct(Shotgun shotgun)
    {
        _shotgun = shotgun;
    }

    private void OnEnable()
    {
        _shotgun.Reloading += Reloading;
        _shotgun.Shooting += Shooting;
    }

    private void OnDisable()
    {
        _shotgun.Reloading -= Reloading;
        _shotgun.Shooting -= Shooting;
    }

    private void Reloading()
    {
        _audioSource.PlayOneShot(_reloadSound);
    }
    private void Shooting()
    {
        _audioSource.PlayOneShot(_shotSound);
        _shotEffect.Play();
        _lightSource.SetActive(true);
        StartCoroutine(LightDisabling());
    }

    private IEnumerator LightDisabling()
    {
        yield return new WaitForSeconds(0.1f);
        _lightSource.SetActive(false);
    }
}
