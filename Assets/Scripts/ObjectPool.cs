using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static Transform masterPool;

    public static string masterPoolName
    {
        get { return "Object Pool"; }
    }

    public static void CreateMasterPool(GameObject[] poolObjects, Transform parentTransform = null)
    {
        GameObject parentObj = new GameObject("Object Pool");
        if(parentTransform != null)
            parentObj.transform.SetParent(parentTransform);
        masterPool = parentObj.transform;
    }

    public static ObjectPool CreatePool(GameObject poolObj)
    {
        ObjectPool pool = new ObjectPool();
        Transform poolParent = new GameObject(poolObj.name + "pool").transform;
        poolParent.gameObject.AddComponent<ObjectPool>();
        return pool;
    }

    private static void ResetPosition(GameObject obj)
    {
        obj.transform.position = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
    }

    private static void Push(ObjectPool pool)
    {

    }

    public static void Pull()
    {

    }

    private static void ResetPosition(GameObject obj, Transform parentTransform)
    {

    }


}
