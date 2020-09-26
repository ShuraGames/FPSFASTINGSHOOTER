using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "WeaponSample/New weapon", order = 0)]
public class WeaponSample : AbstractWeapon
{
    public float weaponDamage = 1f;
    public float weaponDistance = 200f;
    public GameObject bulletWeapon;
    // public GameObject fightAction;
    public LayerMask nonCollisionLayer;
    

    private AssaultRifleAK _weaponShoot;

    public override void Initialize(AssaultRifleAK weapon)
    {
        _weaponShoot = weapon;
        _weaponShoot.Initialize();

        _weaponShoot._maxDistanceRay = weaponDistance;
        if(!_weaponShoot.inChange)
        {
            _weaponShoot.maxAmmo = maxAmmoInStock;
            _weaponShoot.maxAmmoInMagazine = fullMagazine;
            _weaponShoot.inChange = true;
        }
        _weaponShoot.timeReload = reloadTime;
        _weaponShoot._nonIgnoreLayer = nonCollisionLayer;
        _weaponShoot._bulletRifle = bulletWeapon;
        // _weaponShoot._fightAction = fightAction;
    }

    public override void TriggerWeapon()
    {
        _weaponShoot.OnShoot();
    }

    public override void ReloadWeapon()
    {
        _weaponShoot.ReloadWeapon();
    }
}
