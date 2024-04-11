using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int minDam;
    public int maxDam;
    Player playerS;
    public Health healthEnemy;


    private void Start()
    {
        healthEnemy = GetComponent<Health>();
    }
    public void TakeDamage(int damage)
    {
        healthEnemy.TakeDam(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerS = collision.GetComponent<Player>();
            InvokeRepeating("DamagePlayer", 0f, 0.3f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerS = null;
            CancelInvoke("DamagePlayer");
        }
    }

    void DamagePlayer()
    {
        int damage = UnityEngine.Random.Range(minDam, maxDam);
        playerS.TakeDamage(damage);
    }
}
