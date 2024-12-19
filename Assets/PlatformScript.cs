using UnityEngine;

public class PlatformScript : MonoBehaviour
{
	Rigidbody2D rb;
	GameObject player;
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (player != null)
		{
			if (!player.GetComponent<PlayerMovement>().getIsOnPlatform())
			{
				if (player.GetComponent<PlayerMovement>().getHorizontalMove() == 0)
				{
					player.GetComponent<PlayerMovement>().setIsOnPlatform(true);
					player.GetComponent<Rigidbody2D>().linearVelocity = rb.linearVelocity;
					Debug.Log(player);
				}
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//collision.transform.SetParent(transform);
		//Rigidbody2D objRb = collision.gameObject.GetComponent<Rigidbody2D>();

		//if (Mathf.Abs(objRb.linearVelocity.x) <= 0)
		//{
		//	objRb.linearVelocity = new Vector2(10f, rb.linearVelocity.y);
		//	Debug.Log("hello");
		//}
		if (collision.gameObject.CompareTag("Player"))
		{
			player = collision.gameObject;
			Debug.Log(player);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if(player != null)
			{
				player.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, player.GetComponent<Rigidbody2D>().linearVelocity.y);
				player = null;
			}
		}
	}
}
