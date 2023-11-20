using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Wander,
    Attack
}

public class EnemyAttacking : MonoBehaviour
{
    [SerializeField] private State state;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    private EnemyBehaviour enemyBehaviour;
    private Movement playerScript;
    private FieldOfView fieldOfViewScript;

    [SerializeField] private float AttackDistance;
    [SerializeField] private GameObject destination;

    public GameObject Ammo;
    public Transform bulletPoint;

    [SerializeField] private float BulletInterval = 2;
    private float BulletTimer;

    void Start()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
        playerScript = FindObjectOfType<Movement>();
        fieldOfViewScript = GetComponent<FieldOfView>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        state = CheckSwitchConditions();
        switch (state)
        {
            case State.Wander:
                Wander();
                break;

            case State.Attack:
                Attack();
                break;
        }
    }

    private void Wander()
    {
        //activate Enemybehaviour script
        enemyBehaviour.enabled = true;
        navMeshAgent.stoppingDistance = 0;
    }

    private void Attack()
    {
        navMeshAgent.stoppingDistance = 5;
        enemyBehaviour.enabled = false;
        navMeshAgent.SetDestination(destination.transform.position);
        Shoot();
    }

    private State CheckSwitchConditions()
    {
        if (Vector3.Distance(transform.position, enemyBehaviour._Waypoints[enemyBehaviour._currentIndex].position) < AttackDistance && fieldOfViewScript.TargetInVision())
        {
            return State.Attack;
        }
        else return State.Wander;
    }

    private void Shoot()
    {
        transform.LookAt(playerScript.transform);
        BulletTimer += Time.deltaTime;
        if (BulletTimer >= BulletInterval)
        {
            Instantiate(Ammo, bulletPoint.position, bulletPoint.rotation);
            BulletTimer = 0;
        }
    }

}
