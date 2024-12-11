using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
	[SerializeField] protected Transform start;
	[SerializeField] protected Transform end;

	public GameObject obj;
	//public float speed = 40f;

	public bool isGoingRight = true;

	[SerializeField] protected bool checkFacingRight = true;
	public bool destroyed = false;
	protected bool stop = false;
	protected bool isTouchingBack = false;
	protected float timer = 0;
	protected Rigidbody2D rb;

	public void setStop(bool value)
	{
		stop = value;
	}

	public void setIsTouchingBack(bool value)
	{
		isTouchingBack = value;
	}
	
	protected void StopTime()
	{
		rb.linearVelocity = new Vector2(0f, 0f);
		if (timer < 0.5f)
		{
			timer += Time.fixedDeltaTime;
		}
		else
		{
			stop = false;
			isGoingRight = !isGoingRight;
			timer = 0;
		}
	}

	protected void MoveX(float xVelocity = 0, float yVelocity = 0)
	{
		if (!destroyed)
		{
			if (!stop)
			{
				ControlX(xVelocity, yVelocity);
			}
			else
			{
				Debug.Log(isTouchingBack);
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

	protected void ControlX(float xVelocity = 0, float yVelocity = 0, float offset = 0)
	{
		if (isGoingRight)
		{
			if (!checkFacingRight)
			{
				Flip();
			}

			if (obj.transform.position.x + offset + (obj.GetComponent<SpriteRenderer>().bounds.size.x / 2) < end.position.x)
			{
				rb.linearVelocity = new Vector2(xVelocity, yVelocity);
			}
			else
			{
				isGoingRight = !isGoingRight;
			}
		}
		else
		{
			if (checkFacingRight)
			{
				Flip();
			}

			if (obj.transform.position.x - offset - (obj.GetComponent<SpriteRenderer>().bounds.size.x / 2) > start.position.x)
			{
				//transform.position = Vector2.Lerp(transform.position, -1f, speed);
				rb.linearVelocity = new Vector2(-xVelocity, yVelocity);
			}
			else
			{
				isGoingRight = !isGoingRight;
			}

		}
	}

	protected void MoveY(float xVelocity = 0, float yVelocity = 0)
	{
		if (!destroyed)
		{
			if (!stop)
			{
				ControlY(xVelocity, yVelocity);
			}
			else
			{
				Debug.Log(isTouchingBack);
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

	protected void ControlY(float xVelocity = 0, float yVelocity = 0)
	{
		if (isGoingRight)
		{
			if (!checkFacingRight)
			{
				Flip();
			}

			if (obj.transform.position.y + (obj.GetComponent<SpriteRenderer>().bounds.size.y / 2) < end.position.y)
			{
				rb.linearVelocity = new Vector2(xVelocity, yVelocity);
			}
			else
			{
				isGoingRight = !isGoingRight;
			}
		}
		else
		{
			if (checkFacingRight)
			{
				Flip();
			}

			if (obj.transform.position.y - (obj.GetComponent<SpriteRenderer>().bounds.size.y / 2) > start.position.y)
			{
				//transform.position = Vector2.Lerp(transform.position, -1f, speed);
				rb.linearVelocity = new Vector2(xVelocity, -yVelocity);
			}
			else
			{
				isGoingRight = !isGoingRight;
			}

		}
	}
	protected void Flip()
	{
		checkFacingRight = !checkFacingRight;
		obj.transform.Rotate(0f, 180f, 0f);
	}

	public void DestroyEnemy()
	{
		obj.GetComponent<Animator>().SetBool("Death", true);
		
		if (obj.transform.Find("Enemy Head").gameObject)
		{
			Destroy(obj.transform.Find("Enemy Head").gameObject);
		}

		Collider2D[] colliders = obj.GetComponentsInChildren<Collider2D>();

		foreach (Collider2D collider in colliders)
		{
			collider.enabled = false;
		}
		
		destroyed = true;
		rb.linearVelocity = new Vector2(0f, 0f);
		rb.gravityScale = 0f;
		Destroy(gameObject.transform.parent.gameObject, 0.5f);
	}

	private void OnDrawGizmos()
	{
		if (start != null && end != null) 
		{
			Gizmos.DrawLine(obj.transform.position, start.position);
			Gizmos.DrawLine(obj.transform.position, end.position);
		}
	}
}
