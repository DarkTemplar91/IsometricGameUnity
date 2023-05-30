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

    [SerializeField] private Animator animator;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private int maxHealth = 3;
    private int currentHealth;

    private bool isInvincible = false;

    private HealthUIscript uiScript;

    private GameOverScreen gameOverScreen;

    public void Start()
    {
	    currentHealth = maxHealth;
	    uiScript = GameObject.Find("HeartsContainer").GetComponent<HealthUIscript>();
	    gameOverScreen = GameObject.Find("GameOverPanel").GetComponent<GameOverScreen>();
	    gameOverScreen.gameObject.SetActive(false);
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
	    if (isInvincible)
		    return;
	    
	    uiScript.DeleteHeart(currentHealth);

	    currentHealth--;
	    if (currentHealth == 0)
		    Die();
    }
    
    public void IncreaseHp()
    {
	    if (currentHealth == 3)
		    return;
	    
	    currentHealth++;
	    uiScript.AddHeart(currentHealth);

    }

    private void Die()
    {
	    Time.timeScale = 0;
	    gameOverScreen.gameObject.SetActive(true);
	    gameOverScreen.Setup(GameObject.Find("ScoreText").GetComponent<Score>().GetScore());
	    GameObject.Find("Stats").SetActive(false);
    }

    public void SetInvincible(bool invincible)
    {
	    this.isInvincible = invincible;
    }
}
