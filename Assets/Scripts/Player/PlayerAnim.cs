using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement.OnMove += PlayerMovement_OnMove;
        playerMovement.OnStop += PlayerMovement_OnStop;
    }

    private void PlayerMovement_OnMove(object sender, System.EventArgs e)
    {
        GetComponent<Animator>().SetBool("Walk", true);
    }

    private void PlayerMovement_OnStop(object sender, System.EventArgs e)
    {
        GetComponent<Animator>().SetBool("Walk", false);
    }
}
