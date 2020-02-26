using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int activeAmmoCount = 30; // active amount of in-magazine ammo
    public int totalAmmoCount = 550; //total amount of ammo the gun has
    public int maxAmmoCount = 550; // max amount of ammo possible in the gun
    public int magazineSize = 30;

    public void Shoot()
    {
        if(activeAmmoCount > 0)
        {
            activeAmmoCount--;
            // instantiate bullet entity here
        }
    }

    public void Reload()
    {
        if (totalAmmoCount == 0) return; // play "cannot reload" animation

        // play animation
        if(totalAmmoCount - magazineSize < 0)
        {
            activeAmmoCount = totalAmmoCount;
        }
    }
}
