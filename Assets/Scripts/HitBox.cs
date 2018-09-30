using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {
    public GameObject enemy;
    public GameObject player;
    static Animator anim;
    private static bool hit = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    void Update()
    {
    }

    // When collider moves out of other collider triggers hp decrement and hit animation
    void OnTriggerExit(Collider other)
    {
        anim.Play("Hit");
        enemy.GetComponent<Skeleton_Controller>().hp -= 1;
        print(enemy.GetComponent<Skeleton_Controller>().hp);
    }
}
