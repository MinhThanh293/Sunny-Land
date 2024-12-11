using UnityEngine;

public class BorderTest : MonoBehaviour
{
	public Vector2 boundaryMin;  // Góc dưới trái của vùng giới hạn
	public Vector2 boundaryMax;  // Góc trên phải của vùng giới hạn

	private LineRenderer lineRenderer;

	void Start()
	{
		// Tạo hoặc tìm LineRenderer gắn vào đối tượng này
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.positionCount = 5;  // 4 điểm để tạo hình chữ nhật và 1 điểm để nối lại
		lineRenderer.loop = true;  // Để tạo thành vòng kín

		// Thiết lập kiểu đường viền
		lineRenderer.startWidth = 0.1f;
		lineRenderer.endWidth = 0.1f;
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		lineRenderer.startColor = Color.red;
		lineRenderer.endColor = Color.red;

		// Vẽ border
		DrawBorder();
	}

	void DrawBorder()
	{
		Vector3 bottomLeft = new Vector3(boundaryMin.x, boundaryMin.y, 0);
		Vector3 bottomRight = new Vector3(boundaryMax.x, boundaryMin.y, 0);
		Vector3 topLeft = new Vector3(boundaryMin.x, boundaryMax.y, 0);
		Vector3 topRight = new Vector3(boundaryMax.x, boundaryMax.y, 0);

		// Cập nhật vị trí của các điểm vẽ border
		lineRenderer.SetPosition(0, bottomLeft);
		lineRenderer.SetPosition(1, bottomRight);
		lineRenderer.SetPosition(2, topRight);
		lineRenderer.SetPosition(3, topLeft);
		lineRenderer.SetPosition(4, bottomLeft);  // Để nối lại điểm đầu tiên
	}

	// Cập nhật border khi thay đổi các giá trị boundaryMin và boundaryMax
	void OnDrawGizmos()
	{
		if (lineRenderer != null)
		{
			DrawBorder();  // Vẽ lại border khi thay đổi giá trị
		}
	}
}
