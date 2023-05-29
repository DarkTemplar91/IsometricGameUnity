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
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Projectile")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			return;
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
