using UnityEngine;

public class XAxisEnemyController : EnemyControllerScript
{
	[SerializeField] private float xVelocity;
	[SerializeField] private bool useYVelocity = true;
	
	private void Start()
	{
		rb = obj.GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() 
	{
		if (useYVelocity)
		{
			MoveX(xVelocity * 10 * Time.fixedDeltaTime, rb.linearVelocity.y);
		} else
		{
			MoveX(xVelocity * 10 * Time.fixedDeltaTime, 0f);
		}
		
	}
}
