using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject hitEffect;

	void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Projectile")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			return;
        }
		GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
		Destroy(effect, 1f);
		Destroy(gameObject);
	}
}
