using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenScript : MonoBehaviour
{
    public Animator animator;
    public GameObject retryBtn;
    public GameObject backToMenuBtn;
    public Text playerScoreText;
    public Text highScoreText;

    private string playerScoreTmp;
	private bool check = false;
	private void Start()
	{
        playerScoreTmp = $"High Score: {PlayerPrefs.GetInt("High Score", 0)}";
	}

	void Update()
    {
        if (gameObject.activeSelf && !check)
		{
			StartCoroutine(LoadScreen());
		}
    }

    IEnumerator LoadScreen()
    {
        animator.SetTrigger("Start");
		if (StaticStateScript.playerLives <= 0)
		{
			retryBtn.SetActive(false);
		}

        yield return new WaitForSeconds(1);
		if (StaticStateScript.playerLives <= 0)
		{
			highScoreText.gameObject.SetActive(true);

			if (StaticStateScript.playerScore > PlayerPrefs.GetInt("High Score", 0))
			{
				PlayerPrefs.SetInt("High Score", StaticStateScript.playerScore);

				playerScoreTmp = $"High Score: {PlayerPrefs.GetInt("High Score")}!";
				highScoreText.fontStyle = FontStyle.Italic;
				highScoreText.color = Color.red;
			}

			highScoreText.text = playerScoreTmp;

			backToMenuBtn.SetActive(true);
			playerScoreText.gameObject.SetActive(true);
			playerScoreText.text = $"Score: {StaticStateScript.playerScore}";
		}	
		//check = true;
	}
}
