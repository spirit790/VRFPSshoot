using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float curTime;
    public float coolTime;

    public int maxEnemy = 10;

    public List<Vector3> spwanPoint;

    public List<GameObject> enemyPool;


    public void Start()
    {
        enemyPool = new List<GameObject>();
        for (int i = 0; i < maxEnemy; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }
    public void Update()
    {
        curTime += Time.deltaTime;

    }
    public GameObject GetEnmey()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }

        GameObject newEnemy = Instantiate(enemyPrefab);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }


}
