using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGoBRRRR : MonoBehaviour
{
    [SerializeField] private PlayerThrowAim aim;
    [SerializeField] private Transform bomb;
    private bool doShoot;

    private void Start()
    {
        aim.IsAiming += Aim_IsAiming;
    }

    private void Aim_IsAiming(object sender, System.EventArgs e)
    {
        doShoot = true;
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0) && doShoot)
        {
            Instantiate(bomb, new Vector3(transform.position.x, 4f, transform.position.z), transform.rotation);
            doShoot = false;
        }
    }
}
