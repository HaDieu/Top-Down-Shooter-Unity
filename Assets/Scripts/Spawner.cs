using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject xIcon;
    public float xIconDuration = 0.6f;

    IEnumerator SpawnEnemyWithEffect(GameObject enemy)
    {
        ShowXIcon();

        yield return new WaitForSeconds(xIconDuration);

        Instantiate(enemy, transform.position, Quaternion.identity);
    }

    void ShowXIcon()
    {
        StartCoroutine(XEffect());
    }

    IEnumerator XEffect()
    {
        GameObject x = Instantiate(xIcon, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(xIconDuration);

        Destroy(x);
    }

    public void spawnEnemy(GameObject enemy)
    {
        
        StartCoroutine (SpawnEnemyWithEffect(enemy));
        
    }
}
