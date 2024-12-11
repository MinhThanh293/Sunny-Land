using System.Threading;
using UnityEngine;

public class CherryScript : MonoBehaviour
{
    private LogicScript logic;
	private Animator animator;
	[SerializeField] private int point = 50;

    private bool taken = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		animator = GetComponent<Animator>();
		logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player")) 
        {
			if (!taken)
            {
				logic.addCherry(point);
				taken = true;
				animator.SetBool("Taken", true);
				Destroy(gameObject, 0.4f);
            }
			
		}
	}
}
