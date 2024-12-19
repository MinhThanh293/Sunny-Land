using UnityEngine;

public class EnemyAreaScript : MonoBehaviour
{
    Animator animator;
    BoxCollider2D boxCollider;
    public string playerPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = transform.parent.gameObject.GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.transform.position.x > transform.parent.gameObject.transform.position.x)
            {
                playerPosition = "Right";
            }
            else if (collision.gameObject.transform.position.x < transform.parent.gameObject.transform.position.x)
            {
				playerPosition = "Left";
			}
			Debug.Log(playerPosition);
			transform.parent.gameObject.transform.parent.gameObject.GetComponent<TwoStatesEnemyController>().setAwake(true, playerPosition);
            animator.SetBool("Awake", true);

            boxCollider.enabled = false;
        }
	}
}
