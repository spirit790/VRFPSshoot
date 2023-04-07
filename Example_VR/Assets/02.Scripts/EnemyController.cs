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
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD,
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
    public float zombieSpeed = 2f;
    public int eHp = 5;
    public float attackRange = 1.5f;
    public float stateTime;
    public float idleStateTime = 2f;
    public float attackStateTime =1f;
    public float damageStateTime = 1.5f;

    [Header("LockOn")]
    public bool isLockedOn = false;
    public float lockTime;
    public float lockCoolTime = 1f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyState = ENEMYSTATE.IDEL;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyState !=ENEMYSTATE.DEAD)
        switch (enemyState)
        {
            case ENEMYSTATE.NONE:
                    GetComponent<BoxCollider>().enabled = false;
                break;
            case ENEMYSTATE.IDEL:
                    agent.speed = 0;
                    anim.SetInteger("ENEMYSTATE", (int)enemyState);
                    stateTime += Time.deltaTime;
                    if(stateTime> idleStateTime)
                    {
                        stateTime = 0;
                        enemyState = ENEMYSTATE.MOVE;
                    }
                    
                break;
            case ENEMYSTATE.MOVE:
                    anim.SetInteger("ENEMYSTATE", (int)enemyState);
                    agent.SetDestination(target.position);
                    agent.speed = zombieSpeed;
                    float dist = Vector3.Distance(target.position, transform.position);
                    if(dist < attackRange)
                    {
                        enemyState = ENEMYSTATE.ATTACK;
                    }
                    else
                    {
                        agent.speed = zombieSpeed;
                    }
                break;
            case ENEMYSTATE.ATTACK:
                    anim.SetInteger("ENEMYSTATE", (int)enemyState);
                    agent.speed = 0;
                    stateTime += Time.deltaTime;
                    if(stateTime>attackStateTime)
                    {
                        stateTime = 0;
                        Debug.Log("공격");
                    }
                break;
            case ENEMYSTATE.DAMAGE:
                    anim.SetInteger("ENEMYSTATE", (int)enemyState);
                    stateTime += Time.deltaTime;
                    if(stateTime > damageStateTime)
                    {
                        stateTime = 0;
                        enemyState = ENEMYSTATE.MOVE;
                    }
                break;
            case ENEMYSTATE.DEAD:
                    Debug.Log("죽어");
                    anim.SetTrigger("DEAD");
                    enemyState = ENEMYSTATE.NONE;
                    Destroy(gameObject, 2f);

                    break;
            default:
                break;
        }

        if(isLockedOn&&enemyState !=ENEMYSTATE.DEAD)
        {
            lockTime += Time.deltaTime;
            if (lockTime > lockCoolTime)
            {
                lockTime = 0;
                Instantiate(hitEffect, transform.position, transform.rotation);
                enemyState = ENEMYSTATE.DAMAGE;
                DamageByPlayer();
            }
        }
    }
    
    public void DamageByPlayer()
    {
        --eHp;
        if(eHp<=0)
        {
            enemyState = ENEMYSTATE.DEAD;
        }
    }

    public void AimEnter()
    {
        isLockedOn = true;
    }
    public void AimExit()
    {
        isLockedOn = false;
        lockTime = 0;
    }
}
