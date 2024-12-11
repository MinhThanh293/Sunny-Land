using System.Collections;
using UnityEngine;

public class Level_Info_ScreenScript : MonoBehaviour
{   
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {       
		yield return new WaitForSeconds(2);
		animator.SetTrigger("End");
	}
}
