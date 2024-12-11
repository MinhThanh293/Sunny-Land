using System.Collections;
using UnityEngine;

public class TitleScreenScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadTitleScreen());
    }

    IEnumerator LoadTitleScreen()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

}
