using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
	public Rigidbody2D rigidBody;

	public Camera camera;
	Vector2 movement;
	Vector2 mousePos;

    public GameObject tile1;
    public GameObject tile2;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

	void FixedUpdate()
    {

        Debug.Log($"Move by: {moveSpeed * Time.fixedDeltaTime * movement}");
        rigidBody.transform.position = moveSpeed * Time.fixedDeltaTime * movement + rigidBody.position;
        Vector2 lookDirection = mousePos - rigidBody.position;
		float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
		rigidBody.rotation = angle;

        if (Vector2.Distance(transform.position, rigidBody.transform.position) < 5)
        {
            Debug.Log("outside");
            //SpawnTileMap();
        }

    }

    private void SpawnTileMap()
    {
        Instantiate(tile1, transform.position+tile1.transform.localScale, Quaternion.identity);
        Instantiate(tile2, transform.position + tile1.transform.localScale, Quaternion.identity);
    }
}
