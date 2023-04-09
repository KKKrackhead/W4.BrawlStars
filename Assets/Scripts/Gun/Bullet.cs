using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private PlayerShootAim aim;

    private Vector3 bulletMaxDistance;

    private void Start()
    {
        aim = GameObject.Find("AimTrail").GetComponent<PlayerShootAim>();
        bulletMaxDistance = transform.position + transform.forward * aim.trailDistance;
    }

    private void Update()
    {
        if (transform.position == bulletMaxDistance)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * bulletSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}