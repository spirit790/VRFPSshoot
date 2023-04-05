using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameMgr : MonoBehaviour
{
    public ClaySpawner claySpawner;
    public Text scorTxt;
    public int score;
    public bool isClicked = false;
    public float curTime;
    public float coolTime = 3f;
    public GameObject uiCanvas;

    public void ScoreCounter()
    {
        score++;
        scorTxt.text = $"SCORE : {score}";
    }

    public void StartGame()
    {
        claySpawner.spawnerSW = true;
        scorTxt.text = $"SCORE : {score}";
    }

    public void StartBtnEnter()
    {
        isClicked = true;
    }

    public void StartBtnExit()
    {
        isClicked = false;
        curTime = 0;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isClicked)
        {
            curTime += Time.deltaTime;
            if(curTime>coolTime)
            {
                curTime = 0;
                StartGame();
                isClicked = false;
            }
        }
    }
}
