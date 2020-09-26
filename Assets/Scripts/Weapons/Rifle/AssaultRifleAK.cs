using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifleAK : MonoBehaviour
{
    [Header("Params")]
    public bool inChange;
    // [SerializeField] private float _maxDistanceRay = 200f;
    [HideInInspector] public float _maxDistanceRay = 200f;
    public int maxAmmo;
    public int maxAmmoInMagazine;

    public int currentAmmo;
    [HideInInspector] public float timeReload;
    [HideInInspector] public LayerMask _nonIgnoreLayer;

    [Header("Stable Objects")]
    [HideInInspector] public GameObject _bulletRifle;
    public GameObject _fightAction;

    [SerializeField]private int maxAmmoInPack;
    [SerializeField] private Transform _pointInstanceBullet;
    [SerializeField] private Camera fpsCamera;
    [SerializeField] private TriggerWithPlayer _triggerWithPlayer;
//TODO: почистить от личшних выводов в инспектор
    


    private Animator _animator;

    private bool isShooting;

    private void Start() 
    {
        _triggerWithPlayer.triggerGun += ChangeAmmo;
        _triggerWithPlayer.triggerRifle += ChangeAmmo;
        maxAmmoInPack = maxAmmo;
        currentAmmo = maxAmmoInMagazine;
        _animator = GetComponent<Animator>();
    }

    public void Initialize()
    {}

    public void OnShoot()
    {
        if(currentAmmo <= 0)
        {
            ReloadWeapon();
            return;
        }

        Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(rayOrigin, fpsCamera.transform.forward, out hit ,_maxDistanceRay, _nonIgnoreLayer))
        {
            StartCoroutine(FightActionShow());
            currentAmmo--;
            _pointInstanceBullet.LookAt(hit.point);

            // var fight = Instantiate(_fightAction, _pointInstanceBullet.position, Quaternion.identity);
            // Destroy(fight, fight.GetComponent<ParticleSystem>().main.duration);

            var instObj = Instantiate(_bulletRifle, _pointInstanceBullet.position, Quaternion.identity);
            instObj.GetComponent<StandartBullet>().targetPosition = hit.point;
        }
    }

    private IEnumerator FightActionShow()
    {
        _fightAction.SetActive(true);
        _fightAction.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.1f);
        _fightAction.SetActive(false);

    }

    public void ReloadWeapon()
    {
        if(maxAmmo <= 0  || currentAmmo == maxAmmoInMagazine)
        {
            Debug.Log("Sorry, ammo фсе");
            return;
        }

        maxAmmo -= maxAmmoInMagazine;
        currentAmmo = maxAmmoInMagazine;
        Debug.Log(currentAmmo + "I'm reload, sir...");
    }

    public void ChangeAmmo(int ammo)
    {
        Debug.Log("Текущее количество патронов = " + maxAmmo);
        maxAmmo += ammo;
        maxAmmo = Mathf.Clamp(maxAmmo, 0, maxAmmoInPack);
        Debug.Log("Текущее количество патронов после подъема боеприпасов = " + maxAmmo);
    }
}