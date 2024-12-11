using System.Net;
using UnityEngine;

public class PlatformYAxisController : PlatformController
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	public bool isGoingUp = true;

	private void Start()
	{
		rb = platform.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (isGoingUp)
		{
			if (platform.position.y + (platform.GetComponent<SpriteRenderer>().bounds.size.y) < endPoint.position.y)
			{
				rb.linearVelocity = new Vector2(0f, speed * 10 * Time.fixedDeltaTime);
			}
			else
			{
				isGoingUp = !isGoingUp;
			}
		}
		else
		{
			if (platform.position.y - (platform.GetComponent<SpriteRenderer>().bounds.size.y) > startPoint.position.y)
			{
				rb.linearVelocity = new Vector2(0f, -speed * 10 * Time.fixedDeltaTime);
			}
			else
			{
				isGoingUp = !isGoingUp;
			}
		}
	}
}
