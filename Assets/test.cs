using UnityEngine;

public class test : MonoBehaviour
{

	public Transform player; // Đối tượng người chơi
	public float speed = 2f; // Tốc độ di chuyển của kẻ thù
	public float detectionRange = 10f; // Phạm vi phát hiện người chơi
	public LayerMask obstacleLayer; // Lớp vật cản để Raycast phát hiện

	private Rigidbody2D rb;
	private Vector2 movement;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		if (rb == null)
		{
			Debug.LogError("Rigidbody2D chưa được gắn vào kẻ thù!");
		}
	}

	void Update()
	{
		if (player == null)
		{
			Debug.LogWarning("Chưa gắn đối tượng người chơi vào script!");
			return;
		}

		// Tính khoảng cách giữa kẻ thù và người chơi
		float distanceToPlayer = Vector2.Distance(transform.position, player.position);

		if (distanceToPlayer <= detectionRange)
		{
			// Tính toán hướng di chuyển
			Vector2 direction = (player.position - transform.position).normalized;

			// Kiểm tra xem có vật cản phía trước
			RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, obstacleLayer);
			if (hit.collider != null)
			{
				// Nếu gặp vật cản, thay đổi hướng (ví dụ, di chuyển sang bên)
				movement = Vector2.Perpendicular(direction) * speed;
			}
			else
			{
				// Nếu không có vật cản, di chuyển bình thường về phía người chơi
				movement = direction * speed;
			}
		}
		else
		{
			// Nếu người chơi ngoài phạm vi, không di chuyển
			movement = Vector2.zero;
		}
	}

	void FixedUpdate()
	{
		// Di chuyển Rigidbody2D
		rb.linearVelocity = movement;
	}


}
