using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5f;

    private float maxHealth = 100;
    private float currentHealth;

    private Score score;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        score = GameObject.Find("ScoreText").GetComponent<Score>();
    }
    void FixedUpdate()
    {
        rb.transform.position =
            Vector2.MoveTowards(rb.transform.position, target.transform.position, Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            target.GetComponent<PlayerMovement>().DecreaseHp();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        score.IncrementScore();
        Destroy(gameObject);
    }
}
