using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    public GameObject enemy;
    public GameObject weapon;
    public Animator anim;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        //enemy.GetComponent<Skeleton_Controller>().playerHp -= 1;
    }
}