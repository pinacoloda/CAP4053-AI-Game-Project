using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // speed = movement speed, jumpForce = how high you jump
    public float speed;
    public float jumpForce;
    public float gravity;
	private Vector3 moveDirection = Vector3.zero;
    public float rotationSpeed;
    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = gameObject.GetComponent<CharacterController> ();
		
		// Direction movement when not jumping
		if(controller.isGrounded)
		{
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            // Horizontal = sideways, Vertical = front and back
            moveDirection = new Vector3(h, 0, v);
            moveDirection = transform.TransformDirection(moveDirection);
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

            // Determines our movement speed
            moveDirection *= speed;

            PlayAnimation(v, h);
            
            Rolling();
        }

        // Determines how are jump is affected by gravity and frames
        moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

    // Play animation associated with Player Movement
    void PlayAnimation(float v, float h)
    {
        bool leftClick = Input.GetButton("Fire1");
        if (leftClick && v == 0)
        {
            anim.SetBool("isAttacking", true);
            
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }

        // 
        if (v > 0 || h > 0 || h < 0)
        {
            anim.SetBool("isWalking", true);
            // This is where stamina is consumed
            // Add Inviciblity frame later in build
            anim.ResetTrigger("isRolling");
        }
        else if (v < 0)
            anim.SetTrigger("isWalkingBack");
        //anim.SetBool("isWalkingBack", true);
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBack", false);
        }
    }

    // Special method to deal with rolling/Iframe
    void Rolling()
    {
        if(Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isRolling");
        }
    }
}
