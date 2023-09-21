using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPool<T> where T : MonoBehaviour
{
    private readonly List<T> _decals = new List<T>();

    [Inject]
    public ObjectPool(GameObject prefab, int amount)
    {
        CreateObjects(amount, prefab);
    }

    public T GetObject()
    {
        foreach (var obj in _decals)
        {
            if (obj.gameObject.activeSelf == false)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        return null;
    }

    private void CreateObjects(int count, GameObject prefab)
    {
        for (int i = 0; i < count; i++)
        {
            var gameObject = Object.Instantiate(prefab).GetComponent<T>();
            gameObject.gameObject.SetActive(false);
            _decals.Add(gameObject);
        }
    }
}
