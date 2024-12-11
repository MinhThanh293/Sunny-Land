using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleSceneLogic : MonoBehaviour
{
    public Animator animator;
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        animator.gameObject.SetActive(true);
        animator.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
		SceneManager.LoadSceneAsync(sceneName);
	}
}
