using UnityEngine;
using UnityEngine.UI;

public class VictorySceneScript : MonoBehaviour
{
    public Text playerScoreText;
    public Text highScoreText;

    void Start()
    {
        playerScoreText.text = $"Score: {StaticStateScript.playerScore}";
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("High Score", 0)}";

        if (StaticStateScript.playerScore > PlayerPrefs.GetInt("High Score", 0))
        {
            highScoreText.fontStyle = FontStyle.Italic;
            highScoreText.color = Color.red;
        }
    }
}
