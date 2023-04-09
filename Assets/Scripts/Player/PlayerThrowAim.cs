using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerThrowAim : MonoBehaviour
{
    public event EventHandler IsAiming;

    [SerializeField] private LineRenderer line;
    [SerializeField] private Joystick aimJoystick;
    [SerializeField] private Transform aimLookAt;
    [SerializeField] public float trailDistance;
    [SerializeField] private Transform player;

    [SerializeField] private float linePowerY;
    [SerializeField] private float controlledHeight;


    public Vector3[] bombPoint;

    private void Start()
    {
        aimJoystick = GameObject.Find("AimJoystick").GetComponent<Joystick>();
        aimLookAt = GameObject.Find("AimLookAt").GetComponent<Transform>();
        player = GameObject.Find("Kermit").GetComponent<Transform>();

        line.positionCount = (int)trailDistance;
        bombPoint = new Vector3[line.positionCount - 1];
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

            line.SetPosition(0, new Vector3(transform.position.x, transform.position.y + 4 , transform.position.z));

            for (int i = 1; i < line.positionCount; i++)
            {
                line.SetPosition(i, new Vector3(line.GetPosition(i - 1).x + aimJoystick.Horizontal, Mathf.Cos(linePowerY * (i * .2f)) * (i * controlledHeight) + 4, line.GetPosition(i - 1).z + aimJoystick.Vertical));
                IsAiming?.Invoke(this, EventArgs.Empty);
            }
        }
        else if (Mathf.Abs(aimJoystick.Horizontal) < 0.3f || Mathf.Abs(aimJoystick.Vertical) < 0.3f && line.gameObject.activeInHierarchy == true)
        {
            line.gameObject.SetActive(false);
        }
    }
}