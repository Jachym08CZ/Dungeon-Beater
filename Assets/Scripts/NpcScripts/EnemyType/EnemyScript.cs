using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;

    // attack 
    public int Dmg = 10;
    public float Couldown = 1.5F;
    bool alreadyAttacked;

    public LayerMask WhatIsPlayer;
    
    // Patrol Points
    public Transform[] points;
    private int destPoint = 0;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        Patrol();
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrol();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) Attack();
    }
    private void Patrol()
    {
        if (points.Length == 0) return;
        agent.SetDestination(points[destPoint].position);

        if (agent.remainingDistance < 0.5f)
        destPoint = (destPoint + 1) % points.Length;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }
    private void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player.transform.position);

        if (!alreadyAttacked)
        {
            player.GetComponent<PlayerHealthScript>().ChangeHealth(-10);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), Couldown);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
