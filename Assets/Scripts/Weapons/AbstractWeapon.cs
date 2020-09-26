using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class AbstractWeapon : ScriptableObject
{

    public string aName = "New weapon";
    public int maxAmmoInStock;
    public int fullMagazine;
    public float reloadTime;
    public float fireRate;
    // public Animator aAnimaton;
    //TODO: приписать сюда аудиоклип


    public abstract void Initialize(AssaultRifleAK weapon);
    public abstract void TriggerWeapon();
    public abstract void ReloadWeapon();


}
