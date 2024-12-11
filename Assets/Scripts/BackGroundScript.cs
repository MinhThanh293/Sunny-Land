using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    public Transform cam;
    public Transform background1;
    public Transform background2;
    public float length = 24f;

    // Update is called once per frame
    void Update()
    {
        
        if (cam.position.x > background1.position.x)
        {
            background2.position = background1.position + Vector3.right * length;
        }

        if (cam.position.x < background1.position.x)
        {
            background2.position = background1.position + Vector3.left * length;
		}

        if (cam.position.x > background2.position.x || cam.position.x < background2.position.x)
        {
            Transform tmp = background1;
            background1 = background2;
            background2 = tmp;
        }
    }

	private void FixedUpdate()
	{
		transform.position = new Vector3(transform.position.x, cam.position.y, transform.position.z);
	}
}

//using UnityEngine;

//public class BackGroundScript : MonoBehaviour
//{
//	public Transform cam;
//	public Transform background1;
//	public Transform background2;
//	public float moveSpeed = 5f; // Tốc độ di chuyển mượt

//	void Update()
//	{
//		// Di chuyển background theo vị trí camera, nhưng làm mượt với Lerp
//		Vector3 targetPos1 = new Vector3(background1.position.x, cam.position.y, background1.position.z);
//		Vector3 targetPos2 = new Vector3(background2.position.x, cam.position.y, background2.position.z);

//		background1.position = Vector3.Lerp(background1.position, targetPos1, Time.deltaTime * moveSpeed);
//		background2.position = Vector3.Lerp(background2.position, targetPos2, Time.deltaTime * moveSpeed);

//		// Kiểm tra xem camera có đi qua ranh giới giữa các background không
//		if (cam.position.x > background1.position.x)
//		{
//			background2.position = new Vector3(background1.position.x + 24f, background2.position.y, background2.position.z);
//		}

//		if (cam.position.x < background1.position.x)
//		{
//			background2.position = new Vector3(background1.position.x - 24f, background2.position.y, background2.position.z);
//		}

//		// Hoán đổi background khi camera vượt qua
//		if (cam.position.x > background2.position.x || cam.position.x < background2.position.x)
//		{
//			Transform tmp = background1;
//			background1 = background2;
//			background2 = tmp;
//		}
//	}
//}
