using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ShellSoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isActive = true;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isActive)
        {
            _isActive = false;
            _audioSource.Play();
        }
    }
}
