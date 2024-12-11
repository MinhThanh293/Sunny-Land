using UnityEngine;

public class PlatformScript : MonoBehaviour
{
	Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//collision.transform.SetParent(transform);
		Rigidbody2D objRb = collision.gameObject.GetComponent<Rigidbody2D>();

		//if (Mathf.Abs(objRb.linearVelocity.x) <= 0)
		//{
		//	objRb.linearVelocity = new Vector2(10f, rb.linearVelocity.y);
		//	Debug.Log("hello");
		//}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		
	}
}
