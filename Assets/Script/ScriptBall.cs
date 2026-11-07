using UnityEngine;

public class ScriptBall : MonoBehaviour
{

    public Rigidbody2D rb;
    private float timer = 2.0f;
    private float diff = 0.0f;
    private float ballSpeed = 5.0f;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private ScriptGameMaster gameMaster;
    public bool isLaunching = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0,-ballSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // resets the ball if it goes outside the screen
        if (transform.position.y < -9)
        {
            rb.linearVelocity = new Vector2(0,0);
            transform.position = new Vector3( 0f , -1.5f , 0f);
            isLaunching = true;
            scoreManager.increaseScore(-500); // lossing score and a life if the ball goes outside the screen
			gameMaster.LoseLife();
        }

        if (isLaunching)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                rb.linearVelocity = new Vector2(0,-ballSpeed);
                timer = 3.0f;
                isLaunching = false;
            }
        }
		// checks velocity to prevent the ball from only moving side to side without being able to collide with the paddle
            if (rb.linearVelocity.y == 0f && isLaunching == false)
            {
                rb.linearVelocity += new Vector2(0,1);
            }
			if (rb.linearVelocity.x == 0f && isLaunching == false)
            {
                rb.linearVelocity += new Vector2(1,0);
            }
    }
/// <summary>
///When the ball collides with the paddle it will bounce in an interesting manner
///you can "aim" with the ball
/// </summary>
/// <param name="col"></param>
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Paddle")
        {
            diff = gameObject.transform.position.x - col.gameObject.transform.position.x;
            
            rb.linearVelocity += new Vector2(diff*3,0);
        }
    }
/// <summary>
/// Used to change the ball speed for each new level
/// </summary>
/// <param name="speed"></param>
    public void SetSpeed(float speed)
    {
        ballSpeed = speed;
    }
    // same idea, uses for increasing the speed of the ball
    public float GetSpeed()
    {
        return ballSpeed;
    }
}
