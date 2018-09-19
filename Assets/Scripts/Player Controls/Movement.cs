using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    // speed = movement speed, jumpForce = how high you jump
	public float speed = 2f;
	public float jumpForce = 8f;
	public float gravity = 30f;
	private Vector3 moveDirection = Vector3.zero;
    public float rotationSpeed = 50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = gameObject.GetComponent<CharacterController> ();
		
		// Direction movement when not jumping
		if(controller.isGrounded)
		{
            // Horizontal = sideways, Vertical = front and back
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            moveDirection = transform.TransformDirection(moveDirection);
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

            // Determines our movement speed
            moveDirection *= speed;

            // Jumping control(default space key)
            if (Input.GetButtonDown("Jump"))
			{
				moveDirection.y = jumpForce;
			}
        }
		
        // Determines how are jump is affected by gravity and frames
		moveDirection.y -= gravity * Time.deltaTime;
		
		controller.Move(moveDirection * Time.deltaTime);
	}
}
