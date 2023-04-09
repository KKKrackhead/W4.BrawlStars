using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShootAim : MonoBehaviour
{
    public event EventHandler IsAiming;

    [SerializeField] private LineRenderer line;
    [SerializeField] private Joystick aimJoystick;
    [SerializeField] private Transform aimLookAt;
    [SerializeField] public float trailDistance;
    [SerializeField] private Transform player;

    private RaycastHit hit;

    private void Start()
    {
        aimJoystick = GameObject.Find("AimJoystick").GetComponent<Joystick>();
        aimLookAt = GameObject.Find("AimLookAt").GetComponent<Transform>();
        player = GameObject.Find("Kermit").GetComponent<Transform>();
    }

    void Update()
    {
        if (Mathf.Abs(aimJoystick.Horizontal) > 0.3f || Mathf.Abs(aimJoystick.Vertical) > 0.3f)
        {
            if (line.gameObject.activeInHierarchy == false)
            {
                line.gameObject.SetActive(true);
            }

            transform.position = new Vector3(player.position.x, 0, player.position.z);
            line.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 0);

            aimLookAt.position = new Vector3(aimJoystick.Horizontal + player.position.x, 0, aimJoystick.Vertical + player.position.z);

            transform.LookAt(new Vector3(aimLookAt.position.x, 0, aimLookAt.position.z));
            player.LookAt(new Vector3(aimLookAt.position.x, 0, aimLookAt.position.z));
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            line.SetPosition(0, transform.position);

            if (Physics.Raycast(transform.position, transform.forward, out hit, trailDistance))
            {
                line.SetPosition(1, hit.point);
                IsAiming?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                line.SetPosition(1, transform.position + transform.forward * trailDistance);
                IsAiming?.Invoke(this, EventArgs.Empty);
            }
        }
        else if (Mathf.Abs(aimJoystick.Horizontal) < 0.3f || Mathf.Abs(aimJoystick.Vertical) < 0.3f && line.gameObject.activeInHierarchy == true)
        {
            line.gameObject.SetActive(false);
        }
    }
}