using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int s)
    {
        score += s;
        UIManager.Instance.SetScore(score);
    }

    public void GameOver()
    {
        
        SceneManager.LoadScene("Menu");
    }
}