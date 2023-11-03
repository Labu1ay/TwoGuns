using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectPool<T> where T : MonoBehaviour {
    private List<T> pooledObjects = new List<T>();

    public T Instantiate(T obj, Vector3 position = default, Quaternion rotation = default, Transform parent = null) {
        T prefab = GetPooledObject(obj, position, rotation);
            
        prefab.transform.position = position;
        prefab.transform.rotation = rotation;
        if(parent) prefab.transform.SetParent(parent);
            
        prefab.gameObject.SetActive(true);
            
        return prefab;
    }

    private T GetPooledObject(T obj, Vector3 position, Quaternion rotation) {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].gameObject.activeInHierarchy) {
                return pooledObjects[i];
            }
        }
        return CreateObject(obj, position, rotation);
    }

    private T CreateObject(T obj, Vector3 position, Quaternion rotation) {
        T prefab = Object.Instantiate(obj, position, rotation);
        
        prefab.gameObject.SetActive(false);
        pooledObjects.Add(prefab);
            
        return prefab;
    }

    
}