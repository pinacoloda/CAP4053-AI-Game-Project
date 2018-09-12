/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public Transform target;
    public Vector3 currentAngle, newAngle;
    public float speedX;
    public float speedY;
    //private static float temp = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Grab our current Y direction
        //float currentY = transform.eulerAngles.x;
        //print(currentY);

        // Grab our Mouse Y input and rotate that amount
        var y = Input.GetAxis("Mouse Y") * 10f;
        var move = new Vector3(0, 0, -y);

        Quaternion direction = Quaternion.LookRotation(move);
        transform.rotation = Quaternion.Slerp(transform.rotation, direction, Time.deltaTime);
        

        
        
        //print(y);
        //y = Mathf.Clamp(currentY, 49, 290);
        //var temp = gameObject.transform.eulerAngles;
        //temp.Set(-y, 0, 0);
        //if(y != 0)
        //gameObject.transform.localEulerAngles = new Vector3(-y,0,0);
        //transform.Rotate(-y, 0, 0);
        //Mathf.Clamp(y, -100, 100)
        // Grab 
        //float newY = transform.eulerAngles.x;







        //y = Mathf.Clamp(currentAngle.x, 49, 290);

    }

}*/

using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    protected CharacterController characterController;

    protected Vector3 movement;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (characterController == null)
            throw new UnityException("No Character Controller attached to capsule.");
    }

    void Update()
    {

        if (characterController.isGrounded == true)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movement = transform.TransformDirection(movement);
            movement *= 5.0f;

            if (Input.GetKey(KeyCode.Space) == true)
                movement.y = 10.0f;
        }

        movement.y -= 20.0f * Time.deltaTime;

        characterController.Move(movement * Time.deltaTime);
    }
}