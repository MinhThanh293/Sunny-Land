using UnityEngine;

public class StaticStateScript : MonoBehaviour
{
    public static int playerScore = 0;
	public static int playerLives = 5;
	public bool resetHighScore = false;

	public static void resetPlayerScore()
	{
		playerScore = 0;
	}

	public static void resetPlayerLives()
	{
		playerLives = 5;
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		playerScore = 0;
		playerLives = 5;

		if (resetHighScore)
		{
			PlayerPrefs.DeleteKey("High Score");
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
