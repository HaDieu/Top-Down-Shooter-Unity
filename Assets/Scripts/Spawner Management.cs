using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManagement : MonoBehaviour
{
    //public float startTimeBtwSpawn;
    //private float timeBtwSpawn;

    //public GameObject[] enemies;
    //public List<Spawner> spawners;

    //private int maxEnemy = 3;
    //private int roundCount = 0;

    //public List<int> GetRandomIndices(int n, int k)
    //{
    //    List<int> allIndices = new List<int>();
    //    for (int i = 0; i < n; i++)
    //    {
    //        allIndices.Add(i);
    //    }

    //    List<int> randomIndices = new List<int>();

    //    int remainingItems = n;
    //    for (int i = 0; i < k; i++)
    //    {
    //        int randomIndex = Random.Range(0, remainingItems);
    //        randomIndices.Add(allIndices[randomIndex]);
    //        allIndices[randomIndex] = allIndices[remainingItems - 1];
    //        remainingItems--;
    //    }

    //    return randomIndices;
    //}

    //private void Update()
    //{
    //    if (timeBtwSpawn <= 0)
    //    {
    //        int randEnemyCount = Random.Range(2, maxEnemy);
    //        List<int> randomIndex = GetRandomIndices(spawners.Count, randEnemyCount);

    //        foreach (int index in randomIndex)
    //        {
    //            int randEnemy = Random.Range(0, enemies.Length);
    //            spawners[index].spawnEnemy(enemies[randEnemy]);
    //        }

    //        timeBtwSpawn = startTimeBtwSpawn;

    //        roundCount++;
    //        if (roundCount > 10)
    //        {
    //            roundCount = 0;
    //            maxEnemy = Mathf.Max(spawners.Count, maxEnemy + 1);
    //        }
    //    }
    //    else
    //    {
    //        timeBtwSpawn -= Time.deltaTime;
    //    }
    //}

    public float startTimeBtWSpawn;
    float timeBtWSpawn;
    public List<Spawner> spawners;
    public GameObject[] enemies;
    private int maxEnemy = 3;
    private int count;

    private List<int> GetRandonIndices(int n, int k)
    {
        List<int> allIndices = new List<int>();
        for (int i = 0; i < n; i++)
        {
            allIndices.Add(i);
        }

        List<int> randomIndices = new List<int>();

        int remainingIndex = n;

        for (int i = 0;i < k; i++)
        {
            int randomIndex = Random.Range(0, remainingIndex);
            randomIndices.Add(allIndices[randomIndex]);
            allIndices[randomIndex] = allIndices[remainingIndex - 1];
            remainingIndex--;
        }
        return randomIndices;
    }

    private void Update()
    {
        if (timeBtWSpawn <= 0)
        {
            int randEnemyCount = Random.Range(2, maxEnemy);
            List<int> randomIndex = GetRandonIndices(spawners.Count, randEnemyCount);

            foreach (int index in randomIndex)
            {
                int randEnemy = Random.Range(0, enemies.Length);
                spawners[index].spawnEnemy(enemies[randEnemy]);
            }

            timeBtWSpawn = startTimeBtWSpawn;

            count++;
            if(count > 15)
            {
                count = 0;
                maxEnemy = Mathf.Max(spawners.Count, maxEnemy + 1);
            }
        }
        else
        {
            timeBtWSpawn -= Time.deltaTime;
        }
    }
}
