using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static Transform masterPool;
    private Transform[] poolObjects;

    public static string masterPoolName
    {
        get { return "Object Pool"; }
    }

    // create the Master Pool
    // run only once at startup
    public static void CreateMasterPool(GameObject[] poolObjects, Transform parentTransform = null)
    {
        if(GameObject.Find(masterPoolName) == null)
        {
            GameObject parentObj = new GameObject("Object Pool");
            if (parentTransform != null)
                parentObj.transform.SetParent(parentTransform);
            masterPool = parentObj.transform;
        }
    }

    // create basic Object Pool
    public static ObjectPool CreatePool(GameObject poolObj, int quantity)
    {
        Transform poolParent = new GameObject(poolObj.name + "pool").transform;
        poolParent.gameObject.AddComponent<ObjectPool>();
        poolParent.SetParent(masterPool);
        for(int i = 0; i < quantity; i++)
        {
            Instantiate(poolObj, poolParent.position, poolParent.rotation, poolParent);
        }
        return poolParent.GetComponent<ObjectPool>();
    }

    // Take an object OUT of the pool
    public static void Push(ObjectPool pool, Vector3 pos, Quaternion rot)
    {
        Transform obj = pool.transform.GetChild(0);
        if(obj != null)
        {
            ObjectPool.SetPosition(obj, pos, rot);
        }
    }

    public static void PushMultiple(ObjectPool pool, Vector3 pos, Quaternion rot , int quantity)
    {
        // use the child-count here since we need the actual number of available pooled objects
        if (quantity > pool.transform.childCount) quantity = pool.transform.childCount;
        // Then just Push them
        for(int i = 0; i < quantity; i++)
        {
            ObjectPool.Push(pool, pos, rot);
        }
    }

    // Take multiple objects OUT of the pool
    public static void Push(ObjectPool pool, Vector3 pos, Quaternion rot, int quantity)
    {
        if (quantity > pool.transform.childCount) quantity = pool.transform.childCount;
        Transform targetObj = pool.transform.GetChild(0);
        if (targetObj != null)
        {
            targetObj.gameObject.SetActive(true);
            ObjectPool.SetPosition(targetObj, pos, rot);
            targetObj.SetParent(null);
        }
    }

    // Return an object to the pool
    public static void Pull(ObjectPoolObject obj)
    {
        obj.transform.SetParent(obj.parentPool);
        ResetPosition(obj.gameObject , obj.parentPool);
        obj.gameObject.SetActive(false);
    }

    // Pull ALL objects in a given pool
    public static void PullAll(ObjectPool pool)
    {
        foreach(Transform obj in pool.poolObjects)
        {
            ObjectPool.Pull(obj.GetComponent<ObjectPoolObject>());
        }
    }

    // Quick Reset for the position, rotation, and Active status in the heirarchy
    private static void ResetPosition(GameObject obj)
    {
        ObjectPool.SetPosition(obj.transform, Vector3.zero, Quaternion.identity);
        obj.SetActive(false);
    }

    private static void ResetPosition(GameObject obj, Transform parentTransform)
    {
        ObjectPool.SetPosition(obj.transform, Vector3.zero, Quaternion.identity);
        obj.transform.SetParent(parentTransform);
        obj.SetActive(false);
    }

    // Quick position set
    private static void SetPosition(Transform obj , Vector3 pos , Quaternion rot)
    {
        obj.transform.position = pos;
        obj.transform.rotation = rot;
    }

    
    // A class to attach to all objects in a pool
    public class ObjectPoolObject : MonoBehaviour
    {
        public Transform parentPool;
    }
}
