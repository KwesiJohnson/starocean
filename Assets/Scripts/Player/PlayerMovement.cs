using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    private float gravity = 14f;
    private float verticalVelocity;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        /*
        if(controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        */
    }
}
