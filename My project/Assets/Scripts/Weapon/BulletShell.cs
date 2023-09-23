using System.Collections;
using UnityEngine;

public class BulletShell : MonoBehaviour
{
    private float _destroyDelay = 4f;

    private void Start()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        var waitForSeconds = new WaitForSeconds(_destroyDelay);
        yield return waitForSeconds;
        Destroy(gameObject);
    }
}
