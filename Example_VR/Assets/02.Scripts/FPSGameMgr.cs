using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSGameMgr : MonoBehaviour
{
    public ClaySpawner claySpawner;
    public Text scorTxt;
    public int score;
    public bool isClicked = false;
    public float curTime;
    public float coolTime = 3f;
    public GameObject uiCanvas;

    void Start()
    {
        
    }

    void Update()
    {
        if (isClicked)
        {
            curTime += Time.deltaTime;
            if (curTime > coolTime)
            {
                curTime = 0;
                isClicked = false;
            }
        }
    }
}
