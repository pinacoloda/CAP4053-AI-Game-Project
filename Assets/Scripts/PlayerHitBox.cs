using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    public GameObject enemy, trap;
    private static Animator anim;
    //private static Animation spikeTrap;

    // Use this for initialization
    void Start()
    {
        anim = enemy.GetComponent<Animator>();
        //spikeTrap = trap.GetComponent<Animation>();
    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        // Check for enemy animation name "SwingHeavy" set true if it is
    }

    // When collider moves out of hitbox
    void OnTriggerExit(Collider other)
    {
        // If hit was confirmed play animation and decrement hp, reset bool
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("SwingHeavy"))
        {
            // Block is active or is rolling, don't flinch player or decrement hp
            if (!gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Block") ||
                !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Falling To Roll"))
            {
                gameObject.GetComponent<Animator>().Play("HitReaction");
                gameObject.GetComponent<PlayerStats>().playerHP -= 1;
            }
            
            print(gameObject.GetComponent<PlayerStats>().playerHP);
            
        }
    }
    
}