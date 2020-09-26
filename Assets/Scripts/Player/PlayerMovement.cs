using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float _playerSpeed = 5f;
    [SerializeField] private float _jumpPower = 2f;


    private float _gravity;
    private CharacterController _controller;


    private void Start() 
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update() 
    {
        CharacterMove();
        CharacterGravity();

        if(Input.GetButtonDown("Jump"))
        {
            CharacterJump();
        }
    }

    private void CharacterMove()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.up * _gravity + transform.forward * z;

        _controller.Move(move * _playerSpeed * Time.deltaTime);   
    }

    private void CharacterGravity()
    {
        if(!_controller.isGrounded)
        {
            _gravity -= 10f * Time.deltaTime;
        }
        else
        {
            _gravity = -1f;
        }
    }

    private void CharacterJump()
    {
        if(_controller.isGrounded)
        {
            _gravity = _jumpPower;

        }
    }
}
