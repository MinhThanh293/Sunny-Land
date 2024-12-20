using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;
	public Text cherryText;
    public Text gemText;
    public Text playerScoreText;
	public Text heartText;
	public AudioSource levelTheme;
	public AudioSource itemPickUpEffect;
	public AudioSource gameOverSoundEffect;
	[SerializeField] private int cherries = 0;
    [SerializeField] private int gems = 0;
    [SerializeField] private int playerScore = 0;

    public int getPlayerScore()
    {
        return playerScore;
    }

	public static LogicScript Instance;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		//if (Instance == null)
		//{
		//	Instance = this;
		//	DontDestroyOnLoad(gameObject);
		//}
		//else
		//{
		//	Destroy(gameObject);
		//}

		playerScore = StaticStateScript.playerScore;
		playerScoreText.text = StaticStateScript.playerScore.ToString();
		cherries = 0;
        gemText.text = "0";
    }

	// Update is called once per frame
	void Update()
    {
        
    }

    public void restartLevel()
    {
        StartCoroutine(EndGameOverScreen());
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
	}

	IEnumerator EndGameOverScreen()
	{
		//gameOverScreen.transform.Find("Game Over Screen Back Ground").GetComponent<Animator>().SetTrigger("End");
		yield return new WaitForSeconds(1);
		
	}

	public void gameOver()
	{
		levelTheme.Stop();
		gameOverSoundEffect.Play();
		gameOverScreen.SetActive(true);
	}

	public void addCherry(int point)
    {
		cherries += 1;
		cherryText.text = $"{cherries}";
		itemPickUpEffect.Play();
        addPoint(point);
	}

	public void addGem(int point)
	{
		gems += 1;
		gemText.text = $"{gems}";
		itemPickUpEffect.Play();
		addPoint(point);
	}

	public void addPoint(int point)
    {
		playerScore += point;
		StaticStateScript.playerScore = playerScore;
        playerScoreText.text = playerScore.ToString();
    }

    public void displayHeart(int hearts)
    {
		heartText.text = $"{hearts}";
	}
}
