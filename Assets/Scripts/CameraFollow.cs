using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset;
    [SerializeField] private float height;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, height, player.position.z + offset);
    }
}
