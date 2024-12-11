using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
	public Animator sceneAnimator;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject); 
		}
		else
		{
			Destroy(gameObject);
		}
	}
	public void NextLevel()
    {
		StartCoroutine(LoadLevel());
    }

	IEnumerator LoadLevel()
	{
		sceneAnimator.gameObject.SetActive(true);
		sceneAnimator.SetTrigger("End");
		yield return new WaitForSeconds(1);
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
		sceneAnimator.SetTrigger("Start");
		yield return new WaitForSeconds(1);
		sceneAnimator.gameObject.SetActive(false);
	}
}