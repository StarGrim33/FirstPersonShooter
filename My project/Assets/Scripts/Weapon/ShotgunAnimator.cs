using System.Collections;
using UnityEngine;

public class ShotgunAnimator : MonoBehaviour
{
    private Animator _animator;
    private Shotgun _shotgun;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _shotgun = GetComponent<Shotgun>();
        _shotgun.Reloading += Reloading;
    }

    private void OnDisable()
    {
        _shotgun.Reloading -= Reloading;
    }

    private void Reloading()
    {
        _animator.SetBool(Constants.isReloading, true);
        StartCoroutine(StopReloading());
    }

    private IEnumerator StopReloading()
    {
        var waitForSeconds = new WaitForSeconds(3);
        yield return waitForSeconds;
        _animator.SetBool(Constants.isReloading, false);
    }
}
