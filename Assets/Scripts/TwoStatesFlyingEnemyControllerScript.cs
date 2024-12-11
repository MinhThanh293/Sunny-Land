using System;
using UnityEngine;

public class TwoStatesFlyingEnemyControllerScript : TwoStatesEnemyController
{
	[SerializeField] private float xVelocity = 40f;
	[SerializeField] private float yVelocity = 5f;
	[SerializeField] private float xVelocityFlying = 20f;
	[SerializeField] private float yVelocityFlying = 10f;
	[SerializeField] private bool flyDown = true;

	private float objStartYPosition;
	void Start()
	{
		rb = obj.GetComponent<Rigidbody2D>();
		//isFacingRight = false;
		objStartYPosition = obj.transform.position.y;
	}

	private void FixedUpdate()
	{
		Move(Control);
	}

	void Control()
	{
		if (flyDown)
		{
			if (obj.transform.position.y > objStartYPosition - (yVelocity * 10 * Time.fixedDeltaTime))
			{
				ControlX(xVelocityFlying * 10 * Time.fixedDeltaTime, -yVelocityFlying * 10 * Time.fixedDeltaTime);

			}
			else
			{
				ControlX((xVelocity * 10 * Time.fixedDeltaTime), 0f);
			}
		} 
		else
		{
			if (obj.transform.position.y < objStartYPosition + (yVelocity * 10 * Time.fixedDeltaTime))
			{
				ControlX(xVelocityFlying * 10 * Time.fixedDeltaTime, yVelocityFlying * 10 * Time.fixedDeltaTime);

			}
			else
			{
				ControlX((xVelocity * 10 * Time.fixedDeltaTime), 0f);
			}
		}
		
	}

	//[SerializeField] Transform start;
	//[SerializeField] Transform end;
	//[SerializeField] LayerMask excludeLayer;
	//public GameObject obj;
	//public float speed = 40f;

	//bool isFacingRight = false;
	//bool checkFacingRight = true;
	//public bool awake = false;
	//public bool destroyed = false;
	//public bool stop = false;
	//float timer = 0;
	//private Rigidbody2D rb;

	//// Start is called once before the first execution of Update after the MonoBehaviour is created
	//void Start()
	//{
	//	rb = obj.GetComponent<Rigidbody2D>();
	//}

	//// Update is called once per frame
	//void Update()
	//{
	//	if (!destroyed)
	//	{
	//		if (!stop)
	//		{
	//			if (awake)
	//			{

	//				if (obj.transform.position.y > start.position.y)
	//				{

	//					if (isFacingRight)
	//					{
	//						if (!checkFacingRight)
	//						{
	//							Flip();
	//						}

	//						if (obj.transform.position.x < end.position.x)
	//						{
	//							rb.linearVelocity = new Vector2(-20f, -10f) * 10 * Time.fixedDeltaTime;
	//						}
	//						else
	//						{
	//							isFacingRight = !isFacingRight;
	//						}
	//					}
	//					else
	//					{
	//						if (checkFacingRight)
	//						{
	//							Flip();
	//						}

	//						if (obj.transform.position.x > start.position.x)
	//						{
	//							rb.linearVelocity = new Vector2(-20f, -10f) * 10 * Time.fixedDeltaTime;
	//						}
	//						else
	//						{
	//							isFacingRight = !isFacingRight;
	//						}

	//					}
	//				}
	//				else
	//				{
	//					if (isFacingRight)
	//					{
	//						if (!checkFacingRight)
	//						{
	//							Flip();
	//						}

	//						if (obj.transform.position.x < end.position.x)
	//						{
	//							rb.linearVelocity = new Vector2((speed * 10), rb.linearVelocity.y + 5f) * Time.fixedDeltaTime;
	//						}
	//						else
	//						{
	//							isFacingRight = !isFacingRight;
	//						}
	//					}
	//					else
	//					{
	//						if (checkFacingRight)
	//						{
	//							Flip();
	//						}

	//						if (obj.transform.position.x > start.position.x)
	//						{
	//							//transform.position = Vector2.Lerp(transform.position, -1f, speed);
	//							rb.linearVelocity = new Vector2((-speed * 10), rb.linearVelocity.y + -5f) * Time.fixedDeltaTime;
	//						}
	//						else
	//						{
	//							isFacingRight = !isFacingRight;
	//						}

	//					}
	//				}
	//			}
	//		}
	//		else
	//		{
	//			if (timer < 1)
	//			{
	//				timer += Time.fixedDeltaTime;
	//			}
	//			else
	//			{
	//				stop = false;
	//				isFacingRight = !isFacingRight;
	//				timer = 0;
	//			}
	//		}
	//	}
	//	else
	//	{
	//		rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
	//	}

	//}

	//public void Flip()
	//{
	//	checkFacingRight = !checkFacingRight;
	//	obj.transform.Rotate(0f, 180f, 0f);
	//}
}
