using System.Collections;
using UnityEngine;

public interface IWeapon
{
    void PerformShot(Vector3 startPosition, Vector3 direction);

    bool IsReadyToShot();

    IEnumerator Reload();
}
