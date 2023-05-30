using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private Score score;
    private void Start()
    {
        score = GameObject.Find("ScoreText").GetComponent<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Collision with: {collision.name}");
        if (collision.CompareTag("Player"))
        {
            var enemies = FindObjectsOfType<EnemyMovement>();
            foreach (var enemy in enemies)
            {
                score.IncrementScore();
                Destroy(enemy.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
