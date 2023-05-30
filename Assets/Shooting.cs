using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20;

    public float shootRate = 1f;
    private float nextAttackTime;
    

    [SerializeField] private Animator animator;
    private static readonly int IsShooting = Animator.StringToHash("IsShooting");

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GetComponent<Animator>().Play("Character3_Shoot",  -1, 0f);
                Shoot();
                nextAttackTime = Time.time + 1f / shootRate;
            }
            
        }
        
        
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}