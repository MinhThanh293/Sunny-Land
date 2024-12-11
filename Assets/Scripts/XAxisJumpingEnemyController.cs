using UnityEngine;

public class XAxisJumpingEnemyController : EnemyControllerScript
{
	[SerializeField] private float xVelocity = 20f;
	[SerializeField] private float yVelocity = 20f;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private float groundCheckRadius = 0.2f;
	[SerializeField] private LayerMask groundLayer;

	private Animator animator;
	private bool jump = false;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		rb = obj.GetComponent<Rigidbody2D>();
		animator = obj.GetComponent<Animator>();
		//groundCheck = obj.transform.Find("GroundCheck").transform;
		//Debug.Log(obj.transform.Find("GroundCheck").gameObject);
		Debug.Log(xVelocity * 10 * Time.fixedDeltaTime);
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if (!destroyed)
		{
			if (!stop)
			{
				if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
				{
					animator.SetBool("IsFalling", false);
					
					if (timer < 1f)
					{
						timer += Time.fixedDeltaTime;
						//rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
					}
					else
					{
						//Debug.Log("Start:"+ start.position.x);
						//Debug.Log($"Obj: {obj.transform.position.x - xVelocity * 10 * Time.fixedDeltaTime}");
						//Debug.Log($"Obj: {obj.transform.position.x + xVelocity * 10 * Time.fixedDeltaTime}");
						//Debug.Log("End:" + end.position.x);
						ControlX(xVelocity * 10 * Time.fixedDeltaTime, yVelocity * 10 * Time.fixedDeltaTime, xVelocity * 10 * Time.fixedDeltaTime);
						jump = true;
						animator.SetBool("IsJumping", true);
						timer = 0;
					}
				}

				if (jump && rb.linearVelocity.y < 0.1f)
				{
					animator.SetBool("IsJumping", false);
					animator.SetBool("IsFalling", true);
					jump = false;
				}
			}
			else
			{
				if (isTouchingBack)
				{
					isTouchingBack = false;
					stop = false;
				}
				else
				{
					StopTime();
				}
			}
		}
	}
}
