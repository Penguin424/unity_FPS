using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform[] targets;
    private int i = 0;
    private GameObject player;
    [Header("------------Follow PLayer------------")]
    public bool isFollowingPlayer = true;
    [Header("------------------------")]
    public float distanceToPlayer;
    public float distanceToFollowPlayer = 10f;
    public float distanceToFollowPath = 2f;


    void Start()
    {
        agent.SetDestination(targets[i].position);
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < distanceToFollowPlayer && isFollowingPlayer)
        {

            FollowPlayer();
        }
        else
        {

            EnemyPath();
        }
    }

    void FollowPlayer()
    {
        agent.destination = player.transform.position;
    }

    void EnemyPath()
    {

        agent.destination = targets[i].position;

        if (Vector3.Distance(transform.position, targets[i].position) < distanceToFollowPath)
        {
            if (targets[i] == targets[targets.Length - 1])
            {
                i = 0;
            }
            else
            {
                i++;
            }
        }
    }
}
