using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public static PlayerMovement instance;

	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private Transform ceilingCheck;
	[SerializeField] private BoxCollider2D crouchDisableCollider;
	[SerializeField] private CinemachineVirtualCamera playerCamera;
	
	private LayerMask enemyLayer;

	const float groundCheck_Radius = 0.2f;
	const float ceilingCheck_Radius = 0.2f;

	public CharacterController2D controller;
    public Animator animator;
	private LogicScript logic;
	private Rigidbody2D rb;

	public int hearts = 9;
	public float runSpeed = 15f;
	public float jumpForce = 21f;
	public float crouchSpeed = 0.4f;
	public float hurtForce = 10f;
	bool isFacingRight = true;
    float horizontalMove = 0f;
    public bool jump = false;
    bool crouch = false;
	bool hurt = false;
	bool invisible = false;
	bool death = false;
	float timer = 0;
	private bool stop = false;

	public void setStop(bool value)
	{
		this.stop = value;
		rb.linearVelocity = Vector2.zero;
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void Start()
	{
		//if (instance == null)
		//{
		//	instance = this;
		//	DontDestroyOnLoad(gameObject);
		//}
		//else
		//{
		//	Destroy(gameObject);
		//}

		//if (GameObject.FindGameObjectWithTag("Player Position"))
		//{
		//	transform.position = GameObject.FindGameObjectWithTag("Player Position").transform.position;
		//}

		logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
		rb = GetComponent<Rigidbody2D>();

		logic.displayHeart(hearts);

		enemyLayer = LayerMask.GetMask("Enemy");
		Physics2D.IgnoreLayerCollision(gameObject.layer, (int)Mathf.Log(enemyLayer.value, 2), false);
		Debug.Log(gameObject.GetComponent<SpriteRenderer>().transform.position.x + "size");
	}

	// Update is called once per frame
	void Update()
    {
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (!death)
		{
			if (!hurt)
			{
				if (Input.GetButtonDown("Jump") && Physics2D.OverlapCircle(groundCheck.position, groundCheck_Radius, groundLayer))
				{
					Jump();
				}

				if (Input.GetButtonDown("Crouch") && !jump)
				{
					crouch = true;
				}
				else if (Input.GetButtonUp("Crouch"))
				{
					crouch = false;
				}
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//if (collision.gameObject.CompareTag("Enemy"))
		//{
			if (collision.collider.gameObject.CompareTag("Enemy Head"))
			{
				if (!Physics2D.OverlapCircle(groundCheck.position, groundCheck_Radius, groundLayer))
				{
					GameObject enemy = collision.gameObject;
					rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * 10 * Time.fixedDeltaTime);

					logic.addPoint(enemy.GetComponent<EnemyScript>().getPoint());
					enemy.transform.parent.gameObject.GetComponent<EnemyControllerScript>().DestroyEnemy();					
				}
			} 
			else if (collision.collider.gameObject.CompareTag("Enemy"))
			{
				hurt = true;
				animator.SetBool("Hurt", true);

				if (crouch)
				{
					crouch = false;
				}

				collision.gameObject.transform.parent.gameObject.GetComponent<EnemyControllerScript>().setStop(true);
				if (!invisible)
				{
					hearts--;
					logic.displayHeart(hearts);
				
					Physics2D.IgnoreLayerCollision(gameObject.layer, (int)Mathf.Log(enemyLayer.value, 2), true);
					if (hearts == 0)
					{
						playerDie();
					}
					invisible = true;
				}

				if (!death)
				{
					if (collision.transform.position.x > transform.position.x)
					{
						rb.linearVelocity = new Vector2((-hurtForce * 10) * Time.fixedDeltaTime, 0f);
					}
					else
					{
						rb.linearVelocity = new Vector2((hurtForce * 10) * Time.fixedDeltaTime, 0f);
					}
				}
			}
		//}
	}

	//public void OnLanding()
	//   {
	//       animator.SetBool("IsJumping", false);
	//   }

	//   public void OnCrouching(bool isCrouching)
	//   {
	//       animator.SetBool("IsCrouching", isCrouching);
	//   }

	private void FixedUpdate()
	{
		//controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		if (!death && !stop)
		{
			Move();
		}
	}

	public void Jump()
	{
		jump = true;
		animator.SetBool("IsJumping", true);
		rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * 10 * Time.fixedDeltaTime);
	}

	public void playerDie()
	{
		death = true;
		animator.SetBool("Hurt", true);
		rb.linearVelocity = new Vector2(0f, jumpForce * 10 * Time.fixedDeltaTime);
		playerCamera.Follow = null;

		Collider2D[] colliders = GetComponentsInChildren<Collider2D>();

		foreach (Collider2D collider in colliders)
		{
			collider.enabled = false;
		}

		logic.gameOver();
	}

    private void Move()
    {
		if (transform.position.y < -5)
		{
			if (!death)
			{
				playerDie();
			}
		}

        if (crouch)
        {
			horizontalMove *= crouchSpeed;
			crouchDisableCollider.enabled = false;
			animator.SetBool("IsCrouching", true);
		} 
		else
        {
			if (!Physics2D.OverlapCircle(ceilingCheck.position, ceilingCheck_Radius, groundLayer))
			{ 
				crouchDisableCollider.enabled = true;
				animator.SetBool("IsCrouching", false);
			}
			else
			{
				horizontalMove *= crouchSpeed;
			}
			
		}

		if (invisible)
		{
			if (timer < 1.2)
			{
				timer += Time.fixedDeltaTime;
				
				if (timer > 0.5)
				{
					hurt = false;
					animator.SetBool("Hurt", false);
				}
			} 
			else
			{
				invisible = false;
				Physics2D.IgnoreLayerCollision(gameObject.layer, (int)Mathf.Log(enemyLayer.value, 2), false);
				timer = 0;
			}
		}

		if (!hurt)
		{
			rb.linearVelocity = new Vector2((horizontalMove * Time.fixedDeltaTime) * 10, rb.linearVelocity.y);
		}

		if (rb.linearVelocity.y < 0.1f)
		{
			animator.SetBool("IsJumping", false);
			jump = false;

			animator.SetBool("IsFalling", true);
		}

		if (Physics2D.OverlapCircle(groundCheck.position, groundCheck_Radius, groundLayer))
		{
			animator.SetBool("IsFalling", false);
		}

		if (horizontalMove > 0 && !isFacingRight || horizontalMove < 0 && isFacingRight)
        {
			isFacingRight = !isFacingRight;
			transform.Rotate(0f, 180f, 0f);
		}
    }
}

