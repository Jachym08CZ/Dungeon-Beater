using UnityEngine;
using UnityEngine.AI;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;

    public int dmg = 10;
    public float couldown = 1.5f;
    private float timer = 0;

    public Transform[] path;
    private int currentWaypoint = 0; 
    public float followDistance = 5f;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        agent.SetDestination(path[0].position);

    }
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (timer > 0f)
        { timer -= Time.deltaTime; }
        if (Vector3.Distance(transform.position, player.transform.position) < 3f && timer <= 0)
        {
            Attack(dmg);
            timer = couldown;
            Debug.Log($"Attacked {player.gameObject.name}");
        }

        if (distanceToPlayer < followDistance)
        {
            agent.SetDestination(player.transform.position);
            return;
        }
        Patrol();
    }
    void Patrol()
    {
        
        if (agent.remainingDistance < 0.1 + agent.stoppingDistance && !agent.pathPending && agent.hasPath)
        {
            currentWaypoint = (currentWaypoint + 1) % path.Length;
            agent.SetDestination(path[currentWaypoint].position);
        }
    }

    void Attack(int dmg)
    {
        player.transform.gameObject.GetComponent<PlayerHealthScript>().TakeDamage(dmg);
    }
}
