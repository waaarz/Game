using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshPro tmp;
    public static object instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tmp.SetText("Score : " + score);
    }
    /// <summary>
    /// Method that increases the score and displays it on the screen
    /// </summary>
    /// <param name="increase"></param>
    public void increaseScore(int increase)
    {
        if (score + increase < 0)
        {
            score = 0;
        }
        else
        {
            score += increase;
        }
        tmp.SetText("Score : " + score);
    }
}
