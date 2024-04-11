using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossEnemy;
    public float maxTime;
    float time;

    private void Start()
    {
        time = 0;
    }
    private void Update()
    {
        if (time > maxTime)
        {
            GameObject tmp = Instantiate(bossEnemy, transform.position, Quaternion.identity);
            time = 0;
        }

        time += Time.deltaTime;
    }
}
