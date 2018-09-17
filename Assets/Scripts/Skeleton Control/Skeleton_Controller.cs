using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_Controller : MonoBehaviour
{
    public float detectionRadius = 10f;
    // Temp hp, will link classes later
    public float hp = 100;
    public float playerHp = 100;

    Transform target;
    NavMeshAgent agent;
    Animator anim;
    GameObject enemy;

    // Use this for initialization
    void Start ()
    {
        // target will find object name(character in this case)
        target = GameObject.Find("Paladin").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemy = GameObject.Find("Skeleton");
    }

	// Update is called once per frame
	void Update ()
    {
        if(hp>0)
        {
            /*******************************/
            /*      Detected state         */                      
            /*******************************/
            // Determine distance from target
            float distance = Vector3.Distance(target.position, transform.position);

            /*******************************/
            /*     Follow state            */
            /*******************************/
            // If target is within radius start moving the NavMeshAgent
            if ((distance) <= detectionRadius)
            {
                anim.SetBool("isWalking", true);
                agent.SetDestination(target.position);
            }

            /*******************************/
            /*     Stop state              */
            /*******************************/
            // Reached player now determine action
            if (distance <= 2.5)
            {
                agent.isStopped = true;
                anim.SetBool("isWalking", false);

                /*******************************/
                /*     Attack state            */
                /*******************************/
                if (playerHp > 0)
                {
                    anim.SetBool("isAttacking", true);

                    if(playerHp <= 0)
                    {
                        anim.SetBool("isAttacking", false);
                        // Player died, now reset
                    }
                }

                anim.SetBool("isDead", true);
                if (enemy)
                {
                    print("Debug");
                    Destroy(enemy, 1.9f);

                }
            }
            else
            {
                anim.SetBool("isAttacking", false);
                agent.isStopped = false;
            }

            
        }
        else
        {
            anim.SetBool("isDead", true);
            // Death animation plays and despawn Skeleton
        }


	}

    // This shows us detection sphere of enemy
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

    }
}
