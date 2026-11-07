using UnityEngine;

public class EnemyShooter : EnemyBase
{
    public float speed = 3f;
    public GameObject bulletPrefab;
    public float fireRate = 1.2f;
    private float nextFire;

    public override void Move()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public override void Attack()
    {
        if (Time.time >= nextFire)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}