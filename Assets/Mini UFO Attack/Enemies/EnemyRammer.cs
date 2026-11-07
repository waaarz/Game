using UnityEngine;

public class EnemyRammer : EnemyBase
{
    public float speed = 4f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    public override void Move()
    {
        if (!player) return;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}