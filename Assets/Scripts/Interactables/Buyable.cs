using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Buyable : MonoBehaviour
{
    [HideInInspector] public bool inRange = false;
    public GameObject item;
    public int cost;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
            inRange = false;
    }

    public virtual void Buy(PlayerController player)
    {
        if(player.points >= cost)
        {
            player.LosePoints(cost);
            // give the player the item
        }
    }
}
