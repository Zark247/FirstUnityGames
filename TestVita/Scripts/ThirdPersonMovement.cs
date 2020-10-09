using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PSVita;

public class ThirdPersonMovement : MonoBehaviour {

    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float lookSensitivity = 100f;
    float xRotation = 0f;

	// Update is called once per frame
	void Update () {
        //simple movement and look input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float lookX = Input.GetAxis("Right Stick Horizontal") * lookSensitivity * Time.deltaTime;
        float lookY = Input.GetAxis("Right Stick Vertical") * lookSensitivity* Time.deltaTime;
        //direction vector comprised of an x,y,and z, normalized to not affect speed
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //controlls the up and down movement of the camera
        cam.Rotate(Vector3.up * lookX);
        xRotation -= lookY;

        if(direction.magnitude >= 0.1f)
        {
            //retruns the angle in which the player is facing
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //this will smooth the turn angle, before it was snapping to face the direction
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //faces the player in the direction they are traveling
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //player will now face the direction of the camera when moving
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //moves the player in the direction they have input, Time.deltaTime disregards the system specs so it runs the same on every system
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
	}
}
