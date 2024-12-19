using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Info_ScreenScript : MonoBehaviour
{
    public Text levelTitle;
    public Text playerLivesText;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelTitle.text = $"Level {SceneManager.GetActiveScene().buildIndex}";
        playerLivesText.text = $"x  {StaticStateScript.playerLives}";
        animator = GetComponent<Animator>();
        StartCoroutine(LoadLevel());
    }


	IEnumerator LoadLevel()
    {       
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().setStop(true);
		yield return new WaitForSeconds(2);
		animator.SetTrigger("End");
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().setStop(false);
	}
}
