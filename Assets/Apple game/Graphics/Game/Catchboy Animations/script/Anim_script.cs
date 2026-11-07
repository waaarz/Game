using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    float lastDirection = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        if (direction != lastDirection)
        {
            if (direction == 0)
                anim.SetTrigger("idle");
            else if (direction > 0)
                anim.SetTrigger("forward");
            else if (direction < 0)
                anim.SetTrigger("backward");

            lastDirection = direction;
        }

        // Tu peux aussi déplacer le personnage ici :
        transform.position += new Vector3(direction, 0, 0) * Time.deltaTime * 5f;
    }
}