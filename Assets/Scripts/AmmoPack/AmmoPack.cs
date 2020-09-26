using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponType
{
    Gun, 
    Rifle
}

public class AmmoPack : MonoBehaviour
{
    public int bulletCount = 25;
    public WeaponType weaponType;

}
