using System.Collections;
using UnityEngine;

public class DecalDestroyer : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;

    private void OnEnable()
    {
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        var waitForSeconds = new WaitForSeconds(_destroyDelay);
        yield return waitForSeconds;
        gameObject.SetActive(false);
    }
}
