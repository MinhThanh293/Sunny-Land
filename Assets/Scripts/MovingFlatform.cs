using UnityEngine;
using static Pathfinding.SimpleSmoothModifier;

public class MovingFlatform : MonoBehaviour
{
	public Transform platform;
	public Transform startPoint;
	public Transform endPoint;
	public Transform topPoint;
	public Transform bottomPoint;
	public float speed = 1.5f;

	private Rigidbody2D rb;
	public bool checkX = true;
	public bool checkY = true;
	int directionX = 1;
	int directionY = 1;
	Vector3 velocity = Vector3.zero;

	private void Start()
	{
		rb = platform.GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		Vector2 targetX = currentMovementTargetX();
		Vector2 targetY = currentMovementTargetX();

		//platform.position = Vector2.Lerp(platform.position, targetX, speed * Time.fixedDeltaTime);
		if (checkX)
		{


			//platform.transform.Translate(new Vector3(0f, speed * Time.deltaTime, 1));
			rb.linearVelocity = new Vector2(0f, speed * Time.fixedDeltaTime);
			//if (checkX)
			//{
			//	platform.transform.position += new Vector3(-speed * Time.deltaTime, speed * Time.deltaTime, 1);
			//}
			//else
			//{
			//	platform.transform.position += new Vector3(-speed * Time.deltaTime, -speed * Time.deltaTime, 1);
			//}
		}
		else
		{

			//platform.transform.Translate(new Vector3(0f, -speed * Time.deltaTime, 1));
			rb.linearVelocity = new Vector2(0f, -speed * Time.fixedDeltaTime);
			//if (checkX)
			//{
			//	platform.transform.position += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 1);
			//}
			//else
			//{
			//	platform.transform.position += new Vector3(speed * Time.deltaTime, -speed * Time.deltaTime, 1);
			//}
		}

		float Xdistance = (targetX - (Vector2)platform.position).magnitude;
		//float Ydistance = Mathf.Abs((targetY.y - platform.position.y));

		//Debug.Log("X" + Xdistance);
		if (Xdistance < 3f)
		{
			directionX *= -1;
			checkX = !checkX;
		}

		//Debug.Log("Y" + Ydistance);
		//if (Ydistance < 3f)
		//{
		//	directionY *= -1;
		//	checkY = !checkY;
		//}
	}

	Vector2 currentMovementTargetX()
	{
		if (directionX == 1)
		{
			return startPoint.position;
		}
		else
		{
			return endPoint.position;
		}
	}

	Vector2 currentMovementTargetY()
	{
		if (directionY == 1)
		{
			return topPoint.position;
		}
		else
		{
			return bottomPoint.position;
		}
	}

	private void OnDrawGizmos()
	{
		if (platform != null && startPoint != null && endPoint != null)
		{
			Gizmos.DrawLine(platform.transform.position, startPoint.position);
			Gizmos.DrawLine(platform.transform.position, endPoint.position);
		}
	}
}
