using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField] private float speed = 5f;

    private float maxHealth = 100;
    private float currentHealth;

    private Score score;

    private Rigidbody2D rb;
    private GameObject target;
    
    Random rnd = new();
    [SerializeField] private float[] dropRatesForLoot;
    [SerializeField] private GameObject[] loot;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        score = GameObject.Find("ScoreText").GetComponent<Score>();
        target = GameObject.Find("Soldier");
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
        int randomValue = rnd.Next(100);
        Debug.Log($"Value: {randomValue}");
        for (int i = 0; i < loot.Length; i++)
        {
            float lowerBound = (i == 0) ? 0f : dropRatesForLoot[0..(i)].Sum();
            if ( lowerBound < randomValue && randomValue <= dropRatesForLoot[..(i+1)].Sum() )
            {
                Instantiate(loot[i], gameObject.transform.position, Quaternion.identity);
            }
            Debug.Log($"Item{i+1}: Lower bound: {lowerBound}, Upper Bound: {dropRatesForLoot[..(i+1)].Sum()}");
        }
        
        score.IncrementScore();
        Destroy(gameObject);
    }
}
