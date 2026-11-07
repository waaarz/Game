using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelector : MonoBehaviour
{
    public string sceneName;

    public void LoadGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
