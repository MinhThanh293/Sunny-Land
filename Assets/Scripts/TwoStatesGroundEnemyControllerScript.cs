using UnityEngine;

public class TwoStatesGroundEnemyControllerScript : TwoStatesEnemyController
{
	[SerializeField] private float xVelocity = 40f;

	private void Start()
	{
		rb = obj.GetComponent<Rigidbody2D>();
		//isFacingRight = false;
		checkFacingRight = false;
	}

	private void FixedUpdate()
	{
		Move(Run);
	}

	void Run()
	{
		ControlX((xVelocity * 10 * Time.fixedDeltaTime), rb.linearVelocity.y);
	}

	//[SerializeField] Transform start;
	//[SerializeField] Transform end;
	//[SerializeField] LayerMask excludeLayer;
	//public GameObject obj;
	//public float speed = 40f;

	//bool isFacingRight = true;
	//bool checkFacingRight = true;
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
	//			if (isFacingRight)
	//			{
	//				if (!checkFacingRight)
	//				{
	//					Flip();
	//				}

	//				if (obj.transform.position.x < end.position.x)
	//				{
	//					rb.linearVelocity = new Vector2((speed * 10) * Time.fixedDeltaTime, rb.linearVelocity.y);
	//				}
	//				else
	//				{
	//					isFacingRight = !isFacingRight;
	//				}
	//			}
	//			else
	//			{
	//				if (checkFacingRight)
	//				{
	//					Flip();
	//				}

	//				if (obj.transform.position.x > start.position.x)
	//				{
	//					//transform.position = Vector2.Lerp(transform.position, -1f, speed);
	//					rb.linearVelocity = new Vector2((-speed * 10) * Time.fixedDeltaTime, rb.linearVelocity.y);
	//				}
	//				else
	//				{
	//					isFacingRight = !isFacingRight;
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
