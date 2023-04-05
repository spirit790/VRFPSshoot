using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaySpawner : MonoBehaviour
{
    public GameObject clayPrefab;
    public Transform spawnPos;
    public float curTime;
    public float coolTime = 3;
    public bool spawnerSW = false;



    public void StartGame()
    {
        spawnerSW = true;
    }
    private void Start()
    {
    }

    void Update()
    {
        if(spawnerSW)
        {
            curTime += Time.deltaTime;
            if(curTime>coolTime)
            {
                Instantiate(clayPrefab,transform.position, transform.rotation);
                curTime = 0;
            }
        }
    }
}
