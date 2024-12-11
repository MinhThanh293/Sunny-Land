using System;
using UnityEngine;

public class TwoStatesEnemyController : EnemyControllerScript
{
	[SerializeField] protected bool awake = false;
	private string playerPosition;
	public void setAwake(bool value, string playerPosition)
	{
		awake = value;
		this.playerPosition = playerPosition;
	}

	protected void Move(Action action)
	{
		if (!destroyed)
		{
			if (!stop)
			{
				if (awake)
				{
					if (playerPosition == "Right")
					{
						isGoingRight = true;
					}
					else if (playerPosition == "Left")
					{
						isGoingRight = false;
					}
					
					playerPosition = "";

					action();
				}
			}
			else
			{
				if (isTouchingBack)
				{
					isTouchingBack = false;
					stop = false;
				}
				else
				{
					rb.linearVelocity = new Vector2(0f, 0f);
					if (timer < 1)
					{
						timer += Time.fixedDeltaTime;
					}
					else
					{
						stop = false;
						isGoingRight = !isGoingRight;
						timer = 0;
					}
				}
			}
		}
	}
}
