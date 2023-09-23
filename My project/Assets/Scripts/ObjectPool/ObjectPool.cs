using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ObjectPool
{
    private readonly List<GameObject> _decals = new ();
    private readonly List<GameObject> _bulletShells = new();
    private readonly PoolableFactory _factory;

    [Inject]
    public ObjectPool(PoolableFactory factory, int decalsAmount, int shellsAmount)
    {
        _factory = factory;
        _decals = _factory.CreateObjects(PoolableObjects.Decal, decalsAmount);
        _bulletShells = _factory.CreateObjects(PoolableObjects.Shell, shellsAmount);
    }

    public GameObject GetObject(PoolableObjects poolableObjects)
    {
        switch (poolableObjects) 
        { 
            case PoolableObjects.Decal:
                var decal = _decals.FirstOrDefault(x => x != null);
                decal.SetActive(true);
                return decal;

            case PoolableObjects.Shell:
                var instance = _bulletShells.FirstOrDefault(x => x != null);
                instance.SetActive(true);
                return instance;
        }

        return null;
    }
}
