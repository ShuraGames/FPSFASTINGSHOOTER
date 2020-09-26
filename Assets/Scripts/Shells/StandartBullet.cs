using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBullet : MonoBehaviour, IBullets
{
    public int BulletDamage { get; } = 5;
    public float BulletSpeed { get; set; } = 1.8f;

    [HideInInspector] public Vector3 targetPosition = Vector3.zero;

    private Rigidbody _rigidbody;

    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        MoveBullet(targetPosition);
        Destroy(gameObject, 2f);
    }

    private void MoveBullet(Vector3 target)
    {
        transform.rotation = Quaternion.LookRotation(target);
        transform.position = Vector3.MoveTowards(transform.position, target, BulletSpeed);
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
