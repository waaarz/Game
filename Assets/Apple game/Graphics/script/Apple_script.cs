using UnityEngine;

public class Apple_script : MonoBehaviour
{
    // Called once before the first frame update
    void Start()
    {
        
    }

    // Called when this object collides with another 2D collider
    // If the other object has the tag "Panier", destroy this apple
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Panier"))
        {
            Destroy(gameObject);
        }
    }

    // Called once per frame
    void Update()
    {
    
    }
}