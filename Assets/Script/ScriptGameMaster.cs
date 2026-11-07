using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScriptGameMaster : MonoBehaviour
{
    public GameObject Prefab_Brick;
    public ScoreManager scoreManager;
    // dimension of the zone for bricks
    private float startX = -4.8f;
    private float endX = 4.8f;
    private float startY = 2.2f;
    private float endY = -0.5f;
    private float spacingY = 0.55f;
    private float spacingX = 0.85f;
    // different colors for the bricks
    public Color[] colors = { Color.red, Color.darkGreen, Color.cornflowerBlue, Color.limeGreen, Color.softRed, Color.blueViolet }; 
    // variables for the lives features
    public GameObject[] lifeIcons;
    public int lives = 3;
    private int brickNumber = 0 ;
    [SerializeField] private ScriptBall ball;
    public ScriptGameOver gameOverScreen;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        //pressing escape will make the player go bakc to main menu
        
        
        // used for testing the gameOverScreen
        if (Input.GetKey(KeyCode.P))
        {
            ball.isLaunching = true;
            ball.rb.linearVelocity = Vector2.zero;
            gameOverScreen.LoadGameOver(scoreManager.score);
        }
    }
    /// <summary>
    /// Method that creates a level with bricks of different colors placed in a big square
    /// </summary>
    /// <returns></returns>
    public void CreateLevel()
    {
        for (float y = startY; y >= endY; y -= spacingY)
        {
            for (float x= startX; x <= endX; x += spacingX)
            {
                // creation of a new brick 
                GameObject newBrick = Instantiate(Prefab_Brick, new Vector3(x,y,100), Quaternion.identity);
                
                // changing its color
                Color randomcolor = colors[Random.Range(0,colors.Length)];
                SpriteRenderer newSprite = newBrick.GetComponent<SpriteRenderer>();
                newSprite.color = randomcolor;
                
                // associate the script of scoreManager to each new created bricks
                ScriptBrick nbrick = newBrick.GetComponent<ScriptBrick>();
                nbrick.scoreManager = scoreManager;
                nbrick.gameMaster = this; // allows the brick to use method ReportBrickDeath()
                brickNumber++;

            }
        }
    }
    
    /// <summary>
    ///Method that counts the number of bricks still in game
    ///if it goes down to 0 it will present options to the player :
    ///play same level / play next level / main menu
    /// </summary>
    /// <returns></returns>
    public void ReportBrickDeath()
    {
        brickNumber--;
        if (brickNumber == 0)
        {
            ball.isLaunching = true;
            ball.rb.linearVelocity = Vector2.zero;
            gameOverScreen.LoadGameOver(scoreManager.score);
            
            // increase the speed of the ball if the player wins and continues to play
            float currentSpeed = ball.GetSpeed();
            ball.SetSpeed(currentSpeed+0.5f);
            
            CreateLevel();
        }
    }
    /// <summary>
    /// Method that makes the player lose a life if it is called (when the ball is off screen)
    /// If no lives are left, loads the losing screen
    /// </summary>
    /// <returns></returns>
	public void LoseLife()
    {
        lives--;
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            
            lifeIcons[i].SetActive(i < lives);
        }
        
        if (lives <= 0)
        {
            ball.isLaunching = true;
            ball.rb.linearVelocity = Vector2.zero;
            gameOverScreen.LoadGameOver(scoreManager.score);
        }    
    }
}
