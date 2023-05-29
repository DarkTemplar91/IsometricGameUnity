using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
	public Rigidbody2D rigidBody;

	public new Camera camera;
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
}
