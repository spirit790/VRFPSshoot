using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CalyController : MonoBehaviour
{
    private Rigidbody rigd;
    public float pwd = 100;
    public bool isLockedOn = false;
    public float curTime;
    public float coolTime = 0.5f;
    public GameObject explosionEffect;
    public GameMgr gameMgr;


    void Start()
    {
        rigd = GetComponent<Rigidbody>();
        rigd.velocity = transform.forward * pwd;
        Destroy(gameObject, 10f);
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
    }    

    public void AimEnter()
    {
        Debug.Log("조준됨");
        isLockedOn = true;
    }
    public void AimExti()
    {
        Debug.Log("나감");
        isLockedOn = false;
        curTime = 0;

    }
    void Update()
    {
        if(isLockedOn)
        {
            curTime += Time.deltaTime;
            if(curTime>coolTime)
            {
                curTime = 0;
                Instantiate(explosionEffect, transform.position, transform.rotation);
                gameMgr.ScoreCounter();
                Destroy(gameObject);
                
            }
        }
    }
}
