using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleSceneLogic : MonoBehaviour
{
	public AudioSource titleScreenTheme;
	public AudioSource gameStartSoundEffect;
    public Animator animator;
	public Text highScoreText;

	private void Start()
	{
		highScoreText.text = $"High Score: {PlayerPrefs.GetInt("High Score", 0)}";	
	}

	public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        animator.gameObject.SetActive(true);
        animator.SetTrigger("End");
		gameStartSoundEffect.Play();
        yield return new WaitForSeconds(1.5f);
		SceneManager.LoadSceneAsync(sceneName);
		titleScreenTheme.Stop();
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
