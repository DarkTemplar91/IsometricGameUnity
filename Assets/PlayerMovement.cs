using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
	public Rigidbody2D rigidBody;

	public new Camera camera;
	Vector2 movement;
	Vector2 mousePos;

    public GameObject tile1;
    public GameObject tile2;

    [SerializeField] private Animator animator;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private int maxHealth = 3;
    private int currentHealth;

    private HealthUIscript uiScript;

    public void Start()
    {
	    currentHealth = maxHealth;
	    uiScript = GameObject.Find("HeartsContainer").GetComponent<HealthUIscript>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
		
		animator.SetFloat(Speed,Mathf.Abs(movement.magnitude));
    }

	void FixedUpdate()
    {
	    var position = rigidBody.position;
	    rigidBody.transform.position = moveSpeed * Time.fixedDeltaTime * movement + position;
        Vector2 lookDirection = mousePos - position;
		float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
		rigidBody.rotation = angle;

    }

    private void SpawnTileMap()
    {
	    var position = transform.position;
	    var localScale = tile1.transform.localScale;
	    Instantiate(tile1, position+localScale, Quaternion.identity);
        Instantiate(tile2, position + localScale, Quaternion.identity);
    }

    public void DecreaseHp()
    {
	    uiScript.DeleteHeart(currentHealth);

	    currentHealth--;
	    if (currentHealth == 0)
		    Die();
    }

    private void Die()
    {
	    //TODO: Destroy object and show death ui
	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
