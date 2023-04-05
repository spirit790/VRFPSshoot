using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum ENEMYSTATE
    {
        NONE=-1,
        IDEL=0,
        WALK,
        ATTACK,
        DAMAGE,
        DIE,
    }
    [Header("에너미상태")]
    public ENEMYSTATE enemyState;

    private NavMeshAgent agent;
    private Animator anim;
    [Header("타켓 플레이어")]
    public Transform target;
    [Header("히트 이팩트&아이템")]
    public GameObject hitEffect;
    public GameObject item;
    [Header("Enemy")]
    public float speed = 2f;
    public int eHp = 5;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyState = ENEMYSTATE.IDEL;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyState !=ENEMYSTATE.DIE)
        switch (enemyState)
        {
            case ENEMYSTATE.NONE:
                break;
            case ENEMYSTATE.IDEL:
                break;
            case ENEMYSTATE.WALK:
                break;
            case ENEMYSTATE.ATTACK:
                break;
            case ENEMYSTATE.DAMAGE:
                break;
            case ENEMYSTATE.DIE:
                break;
            default:
                break;
        }
    }
    public void MoveChange()
    {

    }
}
