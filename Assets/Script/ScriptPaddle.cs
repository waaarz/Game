using UnityEngine;

public class ScriptPaddle : MonoBehaviour
{
    private float moveSpeed = 10.0f;
    [SerializeField] private float WallLimit = 0.0f ;
    
    // Update is called once per frame
    void Update()
    {
        // Inputs for moving the paddle right or left
        if (Input.GetKey(KeyCode.D)){
            if (transform.position.x > WallLimit) // prevents the paddle from going outside the boundaries
            {
            }
            else transform.Translate(moveSpeed*Time.deltaTime,0,0);
        }
        
        if (Input.GetKey(KeyCode.A)){
            if (transform.position.x < -WallLimit) // prevents the paddle from going outside the boundaries
            {
            }
            else transform.Translate(-moveSpeed*Time.deltaTime,0,0);
        }
    }
}
