using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float _sensetiveMouse = 100f;
    
    [Header("Stable Objects")]
    [SerializeField] private Transform _player;

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * _sensetiveMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensetiveMouse * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        _player.Rotate(Vector3.up * mouseX);        

    }
}
