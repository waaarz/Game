using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_script : MonoBehaviour
{
    private bool isLoading = false;

    void Update()
    {
        if (!isLoading && Input.anyKeyDown)
        {
            isLoading = true;
            StartCoroutine(LoadScene_Game());
        }
    }

    IEnumerator LoadScene_Game()
    {
        AsyncOperation asyncload = SceneManager.LoadSceneAsync("Game apple");
        while (!asyncload.isDone)
        {
            yield return null;
        }
    }
}