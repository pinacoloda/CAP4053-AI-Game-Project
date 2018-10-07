using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleHitBox : MonoBehaviour {
    public GameObject obj, player;
    private static Animator anim;

    // Use this for initialization
    void Start ()
    {
        anim = player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Animator>().Play("HitReaction");
        player.GetComponent<PlayerStats>().playerHP -= 10;
    }
}
