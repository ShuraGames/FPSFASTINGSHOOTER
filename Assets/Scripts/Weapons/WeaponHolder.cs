using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private WeaponUse _use;
    [SerializeField] private List<TemplateWeapons> _template = new List<TemplateWeapons>();

    private int _selectedWeapon = 0; 


    private void Start() 
    {
        _use.Initialize(_template[0]._abstractWeapon, _template[0]._weapon);
        SelectWeapon();
    }

    private void Update() 
    {
        int previousSelectedWeapon = _selectedWeapon;    

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _selectedWeapon = 0;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _selectedWeapon = 1;
        }

        if(previousSelectedWeapon != _selectedWeapon)
            SelectWeapon();
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach( Transform weapon in transform)
        {
            if(i == _selectedWeapon)
            {
                _use.Initialize(_template[i]._abstractWeapon, _template[i]._weapon);
                weapon.gameObject.SetActive(true);
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
