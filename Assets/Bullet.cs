using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject hitEffect;
    private GameObject player;
    [SerializeField] private float maxDistance;

    [SerializeField] private int bulletDamage = 100;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, player.transform.position) > maxDistance)
        {
            DestroyBullet();
        }
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Projectile"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			return;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyMovement>().TakeDamage(bulletDamage);
        }

        DestroyBullet();
	}

    void DestroyBullet()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }
}
