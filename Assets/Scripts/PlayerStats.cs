using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public float playerHP;
    public float stamina;
    public float staminaRefreshRate;
    private static Rigidbody rb;
    private bool isRefreshable = true;
    private static Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRefreshable && stamina >= 0 && stamina <= 10)
            StartCoroutine(staminaRefresh());

        if(playerHP <= 0)
        {
            anim.Play("Death");
            rb.velocity = Vector3.zero;
            transform.position = new Vector3(0.19f, 1.55f, 7.76f);
            playerHP = 10;
        }
	}

    // Every 10 seconds we add +1 stamina to player
    IEnumerator staminaRefresh()
    {
        increment();
        yield return new WaitForSeconds(staminaRefreshRate);
        isRefreshable = true;
    }

    void increment()
    {
        if(stamina <= 10)
            stamina += 1;
        isRefreshable = false;
    }
}
