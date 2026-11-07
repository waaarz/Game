using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenUFOMenu : MonoBehaviour
{
    public string ufoMenuSceneName = "Menu UFO"; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(ufoMenuSceneName);
        }
    }
}