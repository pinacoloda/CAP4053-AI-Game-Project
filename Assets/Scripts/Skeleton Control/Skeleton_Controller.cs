using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_Controller : MonoBehaviour
{
    // Changeable in Unity
    public float detectionRadius = 10f;
    public float hp;
    public float playerHp;
    public GameObject targetObject;
    public GameObject enemy;
    private bool canAttack = true;
    Transform target;
    NavMeshAgent agent;
    Animator anim;

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
        // Get player HP from PlayerStats script
        playerHp = targetObject.GetComponent<PlayerStats>().playerHP;

        if (hp > 0)
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
                anim.StopPlayback();

                /*******************************/
                /*     Attack state            */
                /*******************************/
                if (playerHp > 0)
                {
                    // Call Co-routine for attacking in intervals
                    if(canAttack)
                        StartCoroutine(wait());
                }
                else
                {
                    // Player dead
                }
            }
            else
            {
                agent.isStopped = false;
            }


        }
        else
        {
            // Death animation plays and despawn Skeleton
            anim.Play("Death");
            Destroy(this.gameObject, 1.5f);
        }
	}

    // This shows us detection sphere of enemy
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    // Sword swing interval Co-routine
    void swing()
    {
        // If player is in animation mode attack skeleton can't attack
        if(!targetObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            anim.Play("SwingHeavy");
        canAttack = false;
    }

    IEnumerator wait()
    {
        swing();
        yield return new WaitForSeconds(3f);
        canAttack = true;
    }
}
