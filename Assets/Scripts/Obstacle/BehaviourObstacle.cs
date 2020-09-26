using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BehaviourObstacle : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) 
    {

        ContactPoint[] points = other.contacts;

        //TODO: если проблема не здесь то убрать цикл
        for (int i = 0; i < points.Length; i++)
        {
            IBullets bullet = other.gameObject.GetComponent<IBullets>();
            if(bullet != null)
            {
                _rigidbody.AddForce(points[i].normal * 100f);
            }
        }
    }
}
