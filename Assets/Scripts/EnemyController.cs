using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] protected Transform start;
	[SerializeField] protected Transform end;
	[SerializeField] protected LayerMask excludeLayer;
	[SerializeField] protected GameObject player;
	public GameObject obj;
	public float speed = 40f;

	protected bool isFacingRight = true;
	protected bool checkFacingRight = true;
	public bool destroyed = false;
	public bool stop = false;
	protected bool isTouchingBack = false;
	protected float timer = 0;
	protected Rigidbody2D rb;

	protected void Move(float xVelocity = 0, float yVeloctiy = 0)
	{
		if (!destroyed)
		{
			if (!stop)
			{
				Control(xVelocity, yVeloctiy);
			}
			else
			{

				if (isTouchingBack)
				{
					isTouchingBack = false;
				} 
				else
				{
					rb.linearVelocity = new Vector2(0f, 0f);
					if (timer < 1)
					{
						timer += Time.fixedDeltaTime;
					}
					else
					{
						stop = false;
						isFacingRight = !isFacingRight;
						timer = 0;
					}
				}
			}
		}
		else
		{
			obj.GetComponent<Collider2D>().enabled = false;
			rb.linearVelocity = new Vector2(0f, 0f);
		}
	}

	protected void Control(float xVelocity = 0, float yVelocity = 0)
	{
		if (isFacingRight)
		{
			if (!checkFacingRight)
			{
				Flip();
			}

			if (obj.transform.position.x < end.position.x)
			{
				rb.linearVelocity = new Vector2(xVelocity, yVelocity);
			}
			else
			{
				isFacingRight = !isFacingRight;
			}
		}
		else
		{
			if (checkFacingRight)
			{
				Flip();
			}

			if (obj.transform.position.x > start.position.x)
			{
				//transform.position = Vector2.Lerp(transform.position, -1f, speed);
				rb.linearVelocity = new Vector2(-xVelocity, yVelocity);
			}
			else
			{
				isFacingRight = !isFacingRight;
			}

		}
	}

	protected void Flip()
	{
		checkFacingRight = !checkFacingRight;
		obj.transform.Rotate(0f, 180f, 0f);
	}
}
