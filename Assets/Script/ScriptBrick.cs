using UnityEngine;

public class ScriptBrick : MonoBehaviour
{
    
    public ScoreManager scoreManager;
    public ScriptGameMaster gameMaster;
    
    /// <summary>
    ///Method that adds point and destroy bricks when the ball collides with them
    /// also count the number of destroyed bricks to activate the game over screen
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
            scoreManager.increaseScore(50);
            gameMaster.ReportBrickDeath();
        }
    }
}
