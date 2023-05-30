using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField] private float invincibilityDuration = 10;
    private float invincibilityRemaining;
    private PlayerMovement player;
    private InvincibilityCounter counter;
    private void Start()
    {
        invincibilityRemaining = invincibilityDuration;
        player = GameObject.Find("Soldier").GetComponent<PlayerMovement>();
        counter = GameObject.Find("InvincibilityCounter").GetComponent<InvincibilityCounter>();
    }

    private void Update()
    {
        if( Time.time > invincibilityDuration )
        {
            player.SetInvincible(false);
            counter.ResetText();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Collision with: {collision.name}");
        if (!collision.CompareTag("Player")) return;
        InvokeRepeating(nameof(Countdown), 0, 1);
        player.SetInvincible(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Countdown()
    {
        Debug.Log("Countdown...");
        invincibilityRemaining--;
        counter.RefreshCounter(Convert.ToInt32(invincibilityRemaining));
    }
}
