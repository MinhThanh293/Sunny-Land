using UnityEngine;

public class SpawnedEnemyControllerScript : EnemyControllerScript
{
    public float xVelocity = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = obj.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!destroyed)
        {
            if (!isGoingRight)
            {
                if (checkFacingRight)
                {
                    Flip();
                }
                rb.linearVelocity = new Vector2(-xVelocity * 10 * Time.fixedDeltaTime, rb.linearVelocity.y);
			}
            else
            {
				if (!checkFacingRight)
				{
					Flip();
				}
				rb.linearVelocity = new Vector2(xVelocity * 10 * Time.fixedDeltaTime, rb.linearVelocity.y);
            }
        }
    }
}
