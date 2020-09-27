using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    //speed varaible we can change in the editor
    public float speed = 6f;
    public float smoothTime = 0.1f;
    float smoothTurnVelocity;
    void Update()
    {
        //gets raw input(0 or 1)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //creates a vector for player direction, also prevents extra speed if two keys are pressed at the same time
        Vector3 direction = new Vector3(horizontal,0f,vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            //angle that the player is facing 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }
}
