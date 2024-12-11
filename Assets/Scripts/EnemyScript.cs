using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	[SerializeField] private int killPoint = 100;

	public int getPoint()
	{
		return killPoint;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			bool isGoingRight = transform.parent.gameObject.GetComponent<EnemyControllerScript>().isGoingRight;
			if (isGoingRight && collision.gameObject.transform.position.x < transform.position.x || !isGoingRight && collision.gameObject.transform.position.x > transform.position.x)
			{
				transform.parent.gameObject.GetComponent<EnemyControllerScript>().setIsTouchingBack(true);
			}
		}
	}
	//   public float center;
	//   public float left;
	//public float right;
	//   public float range = 100f;
	//   public float speed = 40f;
	//   bool isFacingRight = true;
	//bool checkFacingRight = true;
	//   private Rigidbody2D rb;

	//   // Start is called once before the first execution of Update after the MonoBehaviour is created
	//   void Start()
	//   {
	//       rb = GetComponent<Rigidbody2D>();
	//       //center = transform.position.x;
	//       //left = center - (range / 2);
	//       //right = center + (range / 2);
	//   }

	//   // Update is called once per frame
	//   void Update()
	//   {
	//	//    rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

	//	//Debug.Log("bunny");
	//	//if (transform.position.x > left)
	//	//{
	//	//	rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
	//	//}
	//	//if (transform.position.x < left)
	//	//{
	//	//	rb.linearVelocity = new Vector2(10f, rb.linearVelocity.y);
	//	//}
	//	if (isFacingRight)
	//	{
	//		if (!checkFacingRight)
	//		{
	//			checkFacingRight = !checkFacingRight;
	//			transform.Rotate(0f, 180f, 0f);
	//		}

	//		if (transform.position.x < right)
	//		{
	//			rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
	//		}
	//		else
	//		{
	//			isFacingRight = !isFacingRight;
	//		}
	//	}
	//	else
	//	{
	//		if (checkFacingRight)
	//		{
	//			checkFacingRight = !checkFacingRight;
	//			transform.Rotate(0f, 180f, 0f);
	//		}
	//		//rb.linearVelocity = new Vector2((rb.linearVelocity.x * speed) * Time.fixedDeltaTime, rb.linearVelocity.y);
	//		//Debug.Log("bunny");
	//		if (transform.position.x > left)
	//		{
	//			//transform.position = Vector2.Lerp(transform.position, -1f, speed);
	//			rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
	//		}
	//		else
	//		{
	//			isFacingRight = !isFacingRight;
	//		}

	//	}

	//}

	//private void FixedUpdate()
	//{

	//}

}
