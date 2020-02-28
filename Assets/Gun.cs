using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour
{
    public int magazineSize = 30;    // actual size of the magazine
    public int activeAmmoCount = 30; // active amount of in-magazine ammo
    public int totalAmmoCount = 550; // total amount of ammo the gun has in-storage
    public int maxAmmoCount = 550;   // max amount of ammo possible in the gun 
    public string gun_name = "Gun Name";


    private AudioSource audioSource;

    private void Awake()
    {
        
    }

    public virtual void Shoot()
    {
        if (activeAmmoCount > 0)
        {
            activeAmmoCount--;
            // instantiate bullet entity here
        }
        else Reload();
    }

    public virtual void AimDownSights()
    {
        // do camera stuff here
        // Manage player things in the PlayerController
    }

    public virtual void Reload()
    {
        if (totalAmmoCount == 0) return; // play "cannot reload" animation

        // play animation
        if(totalAmmoCount - magazineSize < 0)
        {
            activeAmmoCount = totalAmmoCount;
        }
    }
}
