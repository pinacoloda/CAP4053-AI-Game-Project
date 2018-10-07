using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {
    public GameObject enemy;
    static Animator anim;
    public GameObject playerAnim;
    private static bool hit = false;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}

    void Update()
    {

    }

    // When player sword collider enters hitbox
    void OnTriggerEnter(Collider other)
    {
        // Check for current player animation name "Attack" set true if it is
        if (playerAnim.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            hit = true;
        }
    }

    // When player sword collider moves out of hitbox
    void OnTriggerExit(Collider other)
    {
        // If hit was confirmed play animation and decrement hp, reset bool
        if(hit)
        {
            anim.Play("Hit");
            enemy.GetComponent<Skeleton_Controller>().hp -= 1;
            print(enemy.GetComponent<Skeleton_Controller>().hp);
            hit = false;
        }
    }
}
