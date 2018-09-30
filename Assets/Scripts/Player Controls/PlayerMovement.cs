using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // speed = movement speed, jumpForce = how high you jump
    public float fowardSpeed;
    public float strafeSpeed;
    public float backwardsSpeed;
    public float jumpForce;
    public float gravity;
	private Vector3 moveDirection = Vector3.zero;
    public float rotationSpeed;
    private bool iFrame = false;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = gameObject.GetComponent<CharacterController> ();

        // Direction movement when not jumping
        if (controller.isGrounded && anim.GetBool("isAttacking") == false)
        {
            // Horizontal = sideways, Vertical = forward and backwards
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (h != 0 && v != 0)
            {
                // Right Diagnol movement
                if (h > 0)
                {
                    moveDirection = new Vector3((h + v) * 0.7f, 0, v);
                    moveDirection *= fowardSpeed;
                    moveDirection = transform.TransformDirection(moveDirection);
                }
                else // Left Diagnol movement
                {
                    moveDirection = new Vector3(((h - v) * 0.7f), 0, v);
                    moveDirection *= fowardSpeed;
                    moveDirection = transform.TransformDirection(moveDirection);
                }
            }
            else if(v == 0 && h != 0)
            {
                moveDirection = new Vector3(h, 0, v);
                moveDirection *= strafeSpeed;
                moveDirection = transform.TransformDirection(moveDirection);
            }
            else if (v > 0) // Foward movement
            {
                moveDirection = new Vector3(h, 0, v);
                moveDirection *= fowardSpeed;
                moveDirection = transform.TransformDirection(moveDirection);
            }
            else // Backward movement
            {
                moveDirection = new Vector3(h, 0, v);
                moveDirection *= backwardsSpeed;
                moveDirection = transform.TransformDirection(moveDirection);
            }

            // Allows model to rotate while moving diagnol directions
            if(v != 0)
                transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

            // Determines our movement speed
            

            PlayAnimation(v, h);  
        }

        // Determines how are jump is affected by gravity and frames
        moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

    // Play animation associated with Player Movement
    void PlayAnimation(float v, float h)
    {
        iFrame = false;
        // Attack animation
        bool leftClick = Input.GetButton("Fire1");
        if (leftClick && v == 0 && h == 0)
        {
            anim.SetBool("isStraf", false);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isWalking", false);
            anim.Play("Attack");
        }

        // Move Forward
        if (v > 0)
        {
            Rolling(v, h);
            anim.SetBool("isWalking", true);
            anim.SetBool("isStraf", false);
            anim.SetBool("isWalkingBack", false);
        }
        else if (v < 0) // Move Backwards
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isStraf", false);
            anim.SetBool("isWalkingBack", true);
        }
        else if (h != 0 && v == 0) // Move Sideways
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isStraf", true);
        }
        else // Idle
        {
            anim.SetBool("isStraf", false);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isWalking", false);
        }
    }

    // Special method to deal with rolling/Iframe
    void Rolling(float v, float h)
    {
        // This is where stamina is consumed
        // Add Inviciblity frame later in build
        if (Input.GetButtonDown("Jump"))
        {
            anim.Play("Falling To Roll");
            iFrame = true;
        }
        
    }
}
