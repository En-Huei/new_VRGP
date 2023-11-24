using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle,
    Wander,
    RunAway,
    Follow,
    Dead
}
/* This script is used to control the NavMeshAgent of the enemy */
[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentControl : MonoBehaviour
{
    public Transform targetPlayer;
    public bool switchStateByDistance = true;
    public float wanderRadius = 5f;
    public float runAwayRadius = 8f;
    public float zoneRadiusSquare = 20f;
    public EnemyState state = EnemyState.Idle;
    public Camera cam;
    public NavMeshAgent agent;
    void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        if (cam == null)
        {
            cam = Camera.main;
        }
    }
    void Update()
    {
        DetermineState();
        switch (state)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Wander:
                Wander();
                break;
            case EnemyState.RunAway:
                RunAway();
                break;
            case EnemyState.Follow:
                break;
            case EnemyState.Dead:
                break;
            default:
                break;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, wanderRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, runAwayRadius);
    }
    void DetermineState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                state = EnemyState.Follow;
                agent.SetDestination(hit.point);
            }
        }
        if (switchStateByDistance)
        {
            if ((targetPlayer.position - transform.position).sqrMagnitude < zoneRadiusSquare)
            {
                state = EnemyState.RunAway;
            }
            else
            {
                state = EnemyState.Wander;
            }
        }
    }
    void Wander()
    {
        NavMeshHit navHit;
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * wanderRadius;
        if (NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1))
        {
            agent.SetDestination(navHit.position);
        }
    }
    void RunAway()
    {
        NavMeshHit navHit;
        Vector3 randomPoint = transform.position + (transform.position - targetPlayer.position).normalized * runAwayRadius;
        if (NavMesh.SamplePosition(randomPoint, out navHit, runAwayRadius, -1))
        {
            agent.SetDestination(navHit.position);
        }
    }
}
