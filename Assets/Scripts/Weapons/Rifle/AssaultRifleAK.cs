using System;
using UnityEngine;


public class AssaultRifleAK : MonoBehaviour
{
#region PARAMS
    [HideInInspector]public bool inChange;
    [HideInInspector] public int maxAmmo;
    [HideInInspector] public int maxAmmoInMagazine;
    [HideInInspector] public int currentAmmo;
    [HideInInspector] public float maxDistanceRay;
    [HideInInspector] public float timeReload;
    [HideInInspector] public string ammoName;
    [HideInInspector] public LayerMask nonIgnoreLayer;
    [HideInInspector] public WeaponType typeWeapon;
#endregion

    [HideInInspector] public GameObject _bulletRifle;
    public GameObject _fightAction;
    [HideInInspector] public int maxAmmoInPack;

    [SerializeField] private Transform _pointInstanceBullet;
    [SerializeField] private Camera fpsCamera;
    [SerializeField] private TriggerWithPlayer _triggerWithPlayer;

    [SerializeField] private bool _animationEndPlay;
    private WeaponAnimator _weaponAnimator;

    public static event Action<int, int, string> changeAmmo;

    private void Start() 
    {
        if(typeWeapon == WeaponType.Gun)
            _triggerWithPlayer.triggerGun += ChangeAmmo;
        if(typeWeapon == WeaponType.Rifle) 
            _triggerWithPlayer.triggerRifle += ChangeAmmo;
        _weaponAnimator = GetComponent<WeaponAnimator>();
    }

    public void Initialize()
    {
        _animationEndPlay = false;
        changeAmmo?.Invoke(currentAmmo, maxAmmo, ammoName);

        Debug.Log("Initialize from " + typeWeapon.ToString());
    }
#region ShootEvents

    public void OnShoot()
    {
        Debug.Log(_animationEndPlay);
        if(!_animationEndPlay) return;

        if(currentAmmo <= 0)
        {
            ReloadWeapon();
            return;
        }

        Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(rayOrigin, fpsCamera.transform.forward, out hit ,maxDistanceRay, nonIgnoreLayer))
        {
            _weaponAnimator.TriggerWithWeapon("Shoot");
            _fightAction.SetActive(true);

            _fightAction.GetComponent<ParticleSystem>().Play();
            currentAmmo--;

            changeAmmo?.Invoke(currentAmmo, maxAmmo, ammoName);

            _pointInstanceBullet.LookAt(hit.point);

            var instObj = Instantiate(_bulletRifle, _pointInstanceBullet.position, Quaternion.identity);
            instObj.GetComponent<StandartBullet>().targetPosition = hit.point;
        }
    }

    public void ReloadWeapon()
    {
        if(maxAmmo <= 0  || currentAmmo == maxAmmoInMagazine) return;

        _animationEndPlay = false;
        _weaponAnimator.TriggerWithWeapon("Reload");
        maxAmmo -= maxAmmoInMagazine;
        currentAmmo = maxAmmoInMagazine;
    }

#endregion

    public void UpdateUIAmmo()
    {
        changeAmmo?.Invoke(currentAmmo, maxAmmo, ammoName);
    }

    public void ChangeAmmo(int ammo)
    {
        maxAmmo += ammo;
        maxAmmo = Mathf.Clamp(maxAmmo, 0, maxAmmoInPack);
        if(gameObject.activeSelf)
            changeAmmo?.Invoke(currentAmmo, maxAmmo, ammoName);
    }   

    public void AnimationEndPlayed()
    {
        _animationEndPlay = true;
        Debug.Log(_animationEndPlay);
    }
}