using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_Controller : MonoBehaviour
{
    public float detectionRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    Animator anim;

    // Use this for initialization
    void Start ()
    {
        // target will find object name(character in this case)
        target = GameObject.Find("Paladin").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();


    }

	// Update is called once per frame
	void Update ()
    {
        // Determine distance from target
        float distance = Vector3.Distance(target.position, transform.position);

        // If spotted, start walking animation
        if (distance > 0)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

        // If target is within radius start moving the NavMeshAgent
        if (distance <= detectionRadius)
            agent.SetDestination(target.position);

	}

    // This shows us detection sphere of enemy
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

    }
}
