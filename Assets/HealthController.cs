using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement playerMovement;
    private void Start()
    {
        player = GameObject.Find("Soldier");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement.IncreaseHp();
            Destroy(gameObject);
        }
    }
}
