using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
	public GameObject bulletPrefab;

	public float bulletForce = 20;

    public float shootRate = 1f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                nextAttackTime = Time.time + 1f / shootRate;
            }
        }
    }

	void Shoot()
	{
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();
		rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
	}
}
