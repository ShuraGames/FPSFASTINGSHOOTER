using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUse : MonoBehaviour
{
    public string abilityAxisName = "Fire1";

    private float _fireRate;
    private float _nextTimeToFire = 0f;
    private AbstractWeapon _abstractWeapon;
    // [SerializeField] private GameObject _weapon;

    public void Initialize(AbstractWeapon abstractWeapon, AssaultRifleAK weaponHolder)
    {
        _abstractWeapon = abstractWeapon;
        _fireRate = abstractWeapon.fireRate;
        abstractWeapon.Initialize(weaponHolder);
    }

    private void Update() 
    {
        if(Input.GetButton(abilityAxisName) && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;
            _abstractWeapon.TriggerWeapon();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            _abstractWeapon.ReloadWeapon();
        }
    }
}
