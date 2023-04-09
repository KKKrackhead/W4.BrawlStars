using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float bombSpeed;
    [SerializeField] private float boomTime;
    
    private PlayerThrowAim throwAim;
    private Rigidbody rb;

    private Vector3[] points;
    private bool gardyloo;
    private int index;

    private void Start()
    {
        throwAim = GameObject.Find("AimTrail").GetComponent<PlayerThrowAim>();
        rb = transform.GetComponent<Rigidbody>();

        points = new Vector3[14];

        throwAim.bombPoint.CopyTo(points, 0);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * bombSpeed);

        StartCoroutine(BombGoDud());

        if (gardyloo)
        {
            transform.LookAt(points[index]);
        }
        else if ((points[index] - transform.position).sqrMagnitude < .2f)
        {
            if(index == 13)
            {
                rb.useGravity = true;
            }
            else
            {
                index++;
                transform.LookAt(points[index]);
            }
        }
    }

    private IEnumerator BombGoDud()
    {
        yield return new WaitForSecondsRealtime(boomTime);
        Destroy(gameObject);
    }
}
