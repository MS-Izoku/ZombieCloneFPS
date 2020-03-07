using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PickUp : MonoBehaviour
{
    void Awake() {
       GetComponent<SphereCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PickUpEffect();
            if(GetComponent<ObjectPool.ObjectPoolObject>() != null)
                ObjectPool.Pull(GetComponent<ObjectPool.ObjectPoolObject>());
        }
    }

    public virtual void PickUpEffect()
    {
        Debug.Log("Pick Up");
    }
}
