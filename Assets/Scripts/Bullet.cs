using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int minDam;
    public int maxDam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int damage = Random.Range(minDam, maxDam);
            collision.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.CompareTag("BossEnemy"))
        {
            int damage = Random.Range(minDam, maxDam);
            collision.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
