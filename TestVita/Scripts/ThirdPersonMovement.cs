using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour {

    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

	// Update is called once per frame
	void Update () {
        //simple movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //direction vector comprised of an x,y,and z, normalized to not affect speed
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

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
