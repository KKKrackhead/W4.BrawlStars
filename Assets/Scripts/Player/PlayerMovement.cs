using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public event EventHandler OnMove;
    public event EventHandler OnStop;

    [SerializeField] Joystick joystick;
    [SerializeField] Transform moveSprite;
    [SerializeField] private int moveSpeed;
    [SerializeField] private float height;
    [SerializeField] private float offset;


    void FixedUpdate()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            OnMove?.Invoke(this, EventArgs.Empty);
            moveSprite.position = new Vector3(transform.position.x + joystick.Horizontal * offset, height, transform.position.z + joystick.Vertical * offset);

            transform.LookAt(new Vector3(moveSprite.position.x, 0, moveSprite.position.z));
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            OnStop?.Invoke(this, EventArgs.Empty);
            moveSprite.position = transform.position;
        }
    }
}
