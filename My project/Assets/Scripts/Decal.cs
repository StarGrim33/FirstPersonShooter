using System.Collections;
using UnityEngine;

public class Decal : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        var waitForSeconds = new WaitForSeconds(2);
        yield return waitForSeconds;
        gameObject.SetActive(false);
    }
}
