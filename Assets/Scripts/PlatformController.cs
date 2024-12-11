using UnityEngine;

public class PlatformController : MonoBehaviour 
{
	public Transform platform;
	public Transform startPoint;
	public Transform endPoint;
	public float speed = 1.5f;

	protected Rigidbody2D rb;

	//private void FixedUpdate()
	//{
	//	if (isGoingUp)
	//	{


	//		//platform.transform.Translate(new Vector3(0f, speed * Time.deltaTime, 1));
	//		if (platform.position.x < endPoint.position.x && platform.position.y < endPoint.position.y)
	//		{
	//			rb.linearVelocity = new Vector2(speed * Time.fixedDeltaTime, speed * Time.fixedDeltaTime);
	//		}
	//		else
	//		{
	//			isGoingUp = !isGoingUp;
	//		}
			
	//		//if (checkX)
	//		//{
	//		//	platform.transform.position += new Vector3(-speed * Time.deltaTime, speed * Time.deltaTime, 1);
	//		//}
	//		//else
	//		//{
	//		//	platform.transform.position += new Vector3(-speed * Time.deltaTime, -speed * Time.deltaTime, 1);
	//		//}
	//	}
	//	else
	//	{
	//		if (platform.position.x > startPoint.position.x && platform.position.y > startPoint.position.y)
	//		{
	//			rb.linearVelocity = new Vector2(-speed * Time.fixedDeltaTime, -speed * Time.fixedDeltaTime);
	//		}
	//		else
	//		{
	//			isGoingUp = !isGoingUp;
	//		}
	//		//platform.transform.Translate(new Vector3(0f, -speed * Time.deltaTime, 1));
			
	//		//if (checkX)
	//		//{
	//		//	platform.transform.position += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 1);
	//		//}
	//		//else
	//		//{
	//		//	platform.transform.position += new Vector3(speed * Time.deltaTime, -speed * Time.deltaTime, 1);
	//		//}
	//	}
	//}

	private void OnDrawGizmos()
	{
		if (platform != null && startPoint != null && endPoint != null)
		{
			Gizmos.DrawLine(platform.transform.position, startPoint.position);
			Gizmos.DrawLine(platform.transform.position, endPoint.position);
		}
	}

}
