using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletCountsUI : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _weaponNameText;
    [SerializeField] private TextMeshProUGUI _bulletCountText;

    private void Start() 
    {
        AssaultRifleAK.changeAmmo += ShowCountBulletUI;    
    }

    private void ShowCountBulletUI(int currentAmmo, int maxAmmo, string weaponName)
    {
        _weaponNameText.text = weaponName;
        _bulletCountText.text = $"{currentAmmo.ToString()} / {maxAmmo.ToString()}";
    }

}
