using Unity.VisualScripting;
using UnityEngine;

public class XandYAxisEnemyController : EnemyControllerScript
{
	[SerializeField] private Transform top;
	[SerializeField] private Transform bottom;
	[SerializeField] private float xVelocity;
	[SerializeField] private float yVelocity;
	[SerializeField] private float yOffset = 5f;

	bool isGoingUp = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = obj.GetComponent<Rigidbody2D>();
		isGoingRight = false;
		isGoingUp = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		MoveXandY(xVelocity * 10 * Time.fixedDeltaTime, yVelocity * 10 * Time.fixedDeltaTime);
    }

	void MoveXandY(float xVelocity = 0, float yVelocity = 0)
	{
		if (!destroyed)
		{
			if (!stop)
			{
				if (isGoingRight)
				{
					if (!checkFacingRight)
					{
						Flip();
					}

					if (obj.transform.position.x + (obj.GetComponent<SpriteRenderer>().bounds.size.x / 2) < end.position.x)
					{
						setObjYVelocity(xVelocity, yVelocity);
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

					if (obj.transform.position.x - (obj.GetComponent<SpriteRenderer>().bounds.size.x / 2) > start.position.x)
					{
						setObjYVelocity(-xVelocity, yVelocity);
					}
					else
					{
						isGoingRight = !isGoingRight;
					}

				}
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

	void setObjYVelocity(float xVelocity = 0, float yVelocity = 0)
	{
		if (!isGoingUp)
		{
			if (obj.transform.position.y - (obj.GetComponent<SpriteRenderer>().bounds.size.y / 2) > bottom.position.y)
			{
				rb.linearVelocity = new Vector2(xVelocity, -yVelocity);
			}
			else
			{
				isGoingUp = !isGoingUp;
			}
		}
		else
		{
			if (obj.transform.position.y + (obj.GetComponent<SpriteRenderer>().bounds.size.y / 2) < top.position.y)
			{
				rb.linearVelocity = new Vector2(xVelocity, yVelocity);
			}
			else
			{
				isGoingUp = !isGoingUp;
			}
		}
	}

	private void OnDrawGizmos()
	{
		if (start != null && end != null && top != null && bottom != null)
		{
			Gizmos.DrawLine(obj.transform.position, start.position);
			Gizmos.DrawLine(obj.transform.position, end.position);
			Gizmos.DrawLine(obj.transform.position, top.position);
			Gizmos.DrawLine(obj.transform.position, bottom.position);
		}
	}
}
