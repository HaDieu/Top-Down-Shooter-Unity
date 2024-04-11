using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int maxHealth;
    [HideInInspector] public int currentHealth;
    public HealthBar healthBar;
    public float SafeTime = 0.2f;
    float safeTime;
    public bool isDead = false;

    public SpriteRenderer characterSR;
    public Color flashColor = Color.black;
    public float flashDuration = 0.1f;
    Coroutine moveCoroutine;
    private Color originalColor;

    private void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null )
        {
            healthBar.UpdateHealth(currentHealth, maxHealth);
        }

        originalColor = characterSR.color;
    }

    public void TakeDam(int damage)
    {
        if (safeTime <= 0)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                if (this.gameObject.tag == "Enemy")
                {
                    FindObjectOfType<Killed>().UpdateKill(10);
                }

                if (this.gameObject.tag == "BossEnemy")
                {
                    FindObjectOfType<Killed>().UpdateKill(100);
                }

                isDead = true;
                Destroy(this.gameObject, 0.125f);
            }

            if (healthBar != null )
            {
                healthBar.UpdateHealth(currentHealth, maxHealth);
            }

            safeTime = SafeTime;
        }

        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(FlashEffect());

    }

    IEnumerator FlashEffect()
    {
        characterSR.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        characterSR.color = originalColor;
    }

    public void Update()
    {
        safeTime -= Time.deltaTime; 
    }
}
