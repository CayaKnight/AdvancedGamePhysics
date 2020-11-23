using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed=5.0f;
    private Vector3 moveVector;
    private float verticalVelocity=0.0f;
    private float gravity = 12.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity;
        }
        moveVector.x = Input.GetAxisRaw("Horizontal")*speed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;
        controller.Move(moveVector * Time.deltaTime);
   
    }
}
