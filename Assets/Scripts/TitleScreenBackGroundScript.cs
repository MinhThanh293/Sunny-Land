using TMPro;
using UnityEngine;
using static Pathfinding.SimpleSmoothModifier;

public class TitleScreenBackGroundScript : MonoBehaviour
{
	public Transform cam;
	public Transform background1;
	public Transform background2;
	public float length = 24f;
	public float speed = 2f;
	public float smoothTime;

	private Vector3 velocity = Vector3.zero;

	private void Start()
	{
		Move();
	}

	void Update()
	{
		if (cam.position.x > background1.position.x)
		{
			background2.position = background1.position + Vector3.right * length;
		}

		if (cam.position.x > background2.position.x || cam.position.x < background2.position.x)
		{
			Transform tmp = background1;
			background1 = background2;
			background2 = tmp;
		}
		Move();
		//background1.transform.position = Vector3.Lerp(background1.transform.position, new Vector3(background1.transform.position.x - length, background1.transform.position.y, background1.transform.position.z), speed * Time.deltaTime);
	}

	public void Move()
	{
		background1.transform.position = Vector3.SmoothDamp(background1.transform.position, new Vector3(background1.transform.position.x - length, background1.transform.position.y, background1.transform.position.z), ref velocity, smoothTime);
	}
}
