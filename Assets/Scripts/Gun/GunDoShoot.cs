using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDoShoot : MonoBehaviour
{
    [SerializeField] private PlayerShootAim aim;
    [SerializeField] private Transform bullet;
    private bool doShoot;
    private int burst = 3;

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
            StartCoroutine(BurstMode());
            doShoot = false;
        }
    }

    private IEnumerator BurstMode()
    {
        
        Instantiate(bullet, new Vector3(transform.position.x, 4f, transform.position.z), transform.rotation);

        for (int i = 0; i < burst -1; i++)
        {
            yield return new WaitForSecondsRealtime(.2f);
            Instantiate(bullet, new Vector3(transform.position.x, 4f, transform.position.z), transform.rotation);
        }
    }
}
