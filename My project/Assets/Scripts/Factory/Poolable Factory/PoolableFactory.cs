using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PoolableFactory : MonoBehaviour
{
    private GameObject _decalPrefab;
    private GameObject _bulletShellPrefab;

    [Inject]
    private void Construct(GameObject decalPrefab, GameObject bulletShellPrefab)
    {
        _decalPrefab = decalPrefab;
        _bulletShellPrefab = bulletShellPrefab;
    }

    public List<GameObject> CreateObjects(PoolableObjects poolableObjects, int amount)
    {
        List<GameObject> objects = new();

        switch(poolableObjects)
        {
            case PoolableObjects.Decal: 

                for(int i = 0; i < amount; i++)
                {
                    var instance = Instantiate(_decalPrefab, transform.parent);
                    instance.SetActive(false);
                    objects.Add(instance);
                }

                return objects;

            case PoolableObjects.Shell:

                for( int i = 0; i < amount; i++)
                {
                    objects.Add(_bulletShellPrefab);
                }

                return objects;
        }

        return objects;
    }
}
