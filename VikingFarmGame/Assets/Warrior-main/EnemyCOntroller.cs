using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState { CHASE, ATTACK }

public class EnemyCOntroller : MonoBehaviour
{
    private CharacterAnimations EnemyAnimations;
    private NavMeshAgent navagent;
    public GameObject attackPoint;

    private Transform Playertarget;

    public float moveSpeed = 3.5f;
    public float attackDistance = 1.3f;

    public float chasePlayerafterAttackdistance = 1f;

    private float waitbeforeAttckTime = 3f;
    private float AttackTimer;

    private EnemyState enemystate;
    private CharacterSoundFX soundFX;
    // Start is called before the first frame update
    void Awake()
    {
        EnemyAnimations = GetComponent<CharacterAnimations>();
        navagent = GetComponent<NavMeshAgent>();
        Playertarget = GameObject.FindGameObjectWithTag("Player").transform;
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    void Start()
    {
        enemystate = EnemyState.CHASE;
        AttackTimer = waitbeforeAttckTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemystate == EnemyState.CHASE)
        {
            ChasePlayer();
        }

        if (enemystate == EnemyState.ATTACK)
        {
            AttackPlayer();
        }
    }

    void ChasePlayer()
    {
        //follow player to his position        
        navagent.SetDestination(Playertarget.position);
        navagent.speed = moveSpeed;

        if (navagent.velocity.sqrMagnitude == 0)
        {
            EnemyAnimations.Walk(false);
        }
        else
        {
            EnemyAnimations.Walk(true);
        }

        if (Vector3.Distance(Playertarget.position, transform.position) <= attackDistance)
        {
            enemystate = EnemyState.ATTACK;
        }
    }

    void AttackPlayer()
    {
        navagent.velocity = Vector3.zero;
        navagent.isStopped = true;
        EnemyAnimations.Walk(false);
        AttackTimer += Time.deltaTime;
        if (AttackTimer > waitbeforeAttckTime)
        {
            if (Random.Range(0, 2) > 0)
            {
                EnemyAnimations.Attack1();
                soundFX.Attack1();
            }
            else
            {
                EnemyAnimations.Attack2();
                soundFX.Attack2();
            }

            AttackTimer = 0f;
        }

        if (Vector3.Distance(Playertarget.position, transform.position) <= attackDistance + chasePlayerafterAttackdistance)
        {
            navagent.isStopped = false;
            enemystate = EnemyState.CHASE;
        }

    }

    void ActivateAttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void DeactivateAttackPoint()
    {
        if (attackPoint.activeInHierarchy)
            attackPoint.SetActive(false);
    }
}