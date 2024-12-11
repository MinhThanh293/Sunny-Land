using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseCheckPointScript : MonoBehaviour
{
	bool check = false;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (!check)
			{
				StaticStateScript.playerScore = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().getPlayerScore();
				collision.gameObject.GetComponent<PlayerMovement>().setStop(true);
				SceneController.instance.NextLevel();
				check = true;
			}
		}
	}
}
