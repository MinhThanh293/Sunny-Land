using UnityEngine;

public class GemScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private int point = 50;
    private LogicScript logic;
	private bool taken = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        animator = GetComponent<Animator>();
        logic = logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!taken)
            {
                logic.addGem(point);
                taken = true;
				animator.SetBool("Taken", true);
				Destroy(gameObject, 0.4f);
			}
        }
	}
}
