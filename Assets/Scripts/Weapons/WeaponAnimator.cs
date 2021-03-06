﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            BoolWithWeapon("Walk", true);
        }
        else
        {
            BoolWithWeapon("Walk", false);
        }

        if(Input.GetMouseButton(1))
        {
            BoolWithWeapon("Aim", true);
        }
        else
        {
            BoolWithWeapon("Aim", false);
        }
    }

    public void BoolWithWeapon(string animationName,  bool chek)
    {
        _animator.SetBool(animationName, chek);
    }

    public void TriggerWithWeapon(string animationName)
    {
        _animator.SetTrigger(animationName);
    }

    public void ResetTriggerWithWeapon(string animationName)
    {
        _animator.ResetTrigger(animationName);
    }

}
