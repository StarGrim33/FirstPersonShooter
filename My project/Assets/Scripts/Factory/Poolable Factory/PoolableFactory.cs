using System.Collections.Generic;
using UnityEngine;

public class PoolableFactory : MonoBehaviour
{
    [SerializeField] private GameObject _decalPrefab;
    [SerializeField] private GameObject _bulletShellPrefab;
    [SerializeField] private Transform _parent;

    public List<GameObject> CreateObjects(PoolableObjects poolableObjects, int amount)
    {
        List<GameObject> objects = new();

        switch(poolableObjects)
        {
            case PoolableObjects.Decal: 

                for(int i = 0; i < amount; i++)
                {
                    var instance = Instantiate(_decalPrefab, _parent);
                    instance.SetActive(false);
                    objects.Add(instance);
                }

                return objects;

            case PoolableObjects.Shell:

                for( int i = 0; i < amount; i++)
                {
                    var instance = Instantiate(_bulletShellPrefab, _parent);
                    instance.SetActive(false);
                    objects.Add(instance);
                }

                return objects;
        }

        return objects;
    }
}
