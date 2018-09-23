using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {
    public GameObject enemy;
    public GameObject player;
    private static bool hit = false;

	// Use this for initialization
	void Start () {
        
	}

    void Update()
    {
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
       if (Input.GetButton("Fire1"))
        {
            print("Enter");
            enemy.GetComponent<Skeleton_Controller>().hp -= 1;
            hit = true;
        }
    }

    /*
    void OnTriggerExit(Collider other)
    {
        if (hit)
        { 
            //enemy.GetComponent<Skeleton_Controller>().hp -= 1;
            print("Exit");
        }
        hit = false;




    }*/
}
