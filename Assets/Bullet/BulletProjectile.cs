using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody BulletRb;

    private void Awake()
    {
        BulletRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 50f;
        BulletRb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<EnemyHealt>())
        {
            other.GetComponent<EnemyHealt>().Damage(15);
            Destroy(gameObject);
        }
        else if (!other.GetComponent<ThirdPersonController>())
            Destroy(gameObject);
    }
}
