using UnityEngine;

public class SpawnedEnemyControllerScript : EnemyControllerScript
{
    public float deadZone = 10f;
    public float xVelocity = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = obj.GetComponent<Rigidbody2D>();
    }

	private void Update()
	{
		if (Vector2.Distance(obj.transform.position, transform.position) > deadZone)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
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
