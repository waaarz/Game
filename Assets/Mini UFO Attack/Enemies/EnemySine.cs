using UnityEngine;

public class EnemySine : EnemyBase
{
    public float speed = 3f;
    public float freq = 4f;
    public float amp = 1.6f;
    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    public override void Move()
    {
        float x = startPos.x - speed * Time.time;
        float y = startPos.y + Mathf.Sin(Time.time * freq) * amp;
        transform.position = new Vector2(x, y);
    }
}