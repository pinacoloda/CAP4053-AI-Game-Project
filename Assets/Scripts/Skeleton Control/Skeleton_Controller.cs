using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_Controller : MonoBehaviour
{
    public float detectionRadius = 10f;
    // Temp hp, will link classes later
    public float hp;
    public float playerHp;

    Transform target;
    NavMeshAgent agent;
    Animator anim;
    public GameObject targetObject;
    public GameObject enemy;

    // Use this for initialization
    void Start ()
    {
        // Enemy is the AI, target is the player
        target = targetObject.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<GameObject>();
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
            if (distance <= 3f)
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
                        // Player died, now reset
                    }
                }
                else
                {
                    //print("Player dead");
                    //Destroy(enemy, 1);
                    
                }
                /*
                anim.SetBool("isDead", true);
                if (enemy)
                {
                    print("Debug");
                    Destroy(enemy, 1.9f);

                }*/
            }
            else
            {
                anim.SetBool("isAttacking", false);
                agent.isStopped = false;
            }

            
        }
        else
        {
            // Death animation plays and despawn Skeleton
            anim.SetTrigger("isDead");
            Destroy(this.gameObject, 2.5f);    
        }


	}

    // This shows us detection sphere of enemy
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

    }
}
