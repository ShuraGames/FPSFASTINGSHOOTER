using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBullet : MonoBehaviour, IBullets
{
    public int BulletDamage { get; } = 5;
    public float BulletSpeed { get; set; } = 10f;

    [HideInInspector] public Vector3 targetPosition = Vector3.zero;

    private Rigidbody _rigidbody;
    private Vector3 _startPoint;

    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPoint = transform.position;

    }

    private void FixedUpdate() 
    {
        MoveBullet(targetPosition);
        Destroy(gameObject, 2f);
    }

    private void MoveBullet(Vector3 target)
    {
        Vector3 direction = target - _startPoint;
        
        transform.forward = direction.normalized;

        _rigidbody.AddForce(direction.normalized * BulletSpeed, ForceMode.Impulse);
    }



    private void OnCollisionEnter(Collision other) 
    {
        Hit hitObj = other.gameObject.GetComponent<Hit>();

        if(hitObj != null)
            hitObj.Accept(new HitEffectSpawner(), other.contacts[0].point);

        Debug.Log("Hit");
        Destroy(gameObject);
    }
}
