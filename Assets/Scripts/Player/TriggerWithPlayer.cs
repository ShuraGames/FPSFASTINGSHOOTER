using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWithPlayer : MonoBehaviour
{
    public delegate void OnTriggerAmmoPack(int ammoCount);
    public event OnTriggerAmmoPack triggerGun;
    public event OnTriggerAmmoPack triggerRifle;

    private void OnTriggerEnter(Collider other) 
    {
        var ammo = other.GetComponent<AmmoPack>();

        if(ammo != null)
        {
            if(ammo.weaponType == WeaponType.Gun)
                triggerGun?.Invoke(ammo.bulletCount);
            if(ammo.weaponType == WeaponType.Rifle)
                triggerRifle?.Invoke(ammo.bulletCount);
            Destroy(other.gameObject);
        }
    }
}
