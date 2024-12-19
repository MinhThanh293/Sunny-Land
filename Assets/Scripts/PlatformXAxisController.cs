using UnityEngine;

public class FlatformXAxisController : PlatformController
{
	public bool isGoingRight = true;

	private void Start()
	{
		rb = platform.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
    {
		if (isGoingRight)
		{
			if (platform.position.x + (platform.GetComponent<SpriteRenderer>().bounds.size.x / 2) < endPoint.position.x)
			{
				rb.linearVelocity = new Vector2(speed * 10 * Time.fixedDeltaTime, 0f);
			}
			else
			{
				isGoingRight = !isGoingRight;
			}
		}
		else
		{
			if (platform.position.x - (platform.GetComponent<SpriteRenderer>().bounds.size.x / 2) > startPoint.position.x)
			{
				rb.linearVelocity = new Vector2(-speed * 10 * Time.fixedDeltaTime, 0f);
			}
			else
			{
				isGoingRight = !isGoingRight;
			}
		}
	}
}
