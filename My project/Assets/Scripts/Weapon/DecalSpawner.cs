using UnityEngine;

public class DecalSpawner
{
    private int _decalLayer = 8;

    public void SpawnDecal(int layer, ObjectPool objectPool, RaycastHit hit, float offSet)
    {
        if (layer == _decalLayer)
        {
            var decal = objectPool.GetObject(PoolableObjects.Decal);
            decal.transform.position = hit.point + hit.normal * offSet;
            decal.transform.LookAt(hit.point);
            decal.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
    }
}
