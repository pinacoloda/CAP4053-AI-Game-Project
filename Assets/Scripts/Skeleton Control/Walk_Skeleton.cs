using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Walk_Skeleton: MonoBehaviour {

	public Animator anim;

    public NavMeshAgent agent;

    public Transform target;
    public Vector3 getPosition;

    

	void start()
	{
		anim = GetComponent<Animator> ();
       
	}

	void Update()
	{
        // Grab movement axis
        getPosition = transform.position;

        float move = Vector3.Distance(transform.position, getPosition);
        // If movement V/H is not 0 we use change boolean expression within Animator
        //if (move > 0)
            //anim.SetBool("isWalking", true);
        //else
            //anim.SetBool("isWalking", false);

    }
}
