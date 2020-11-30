using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private AudioSource deathSound;
    private CharacterController controller;
    public float speed=5.0f;
    private Vector3 moveVector;
    private float verticalVelocity=0.0f;
    private float gravity = 12.0f;
    private bool isDead = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        deathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadScene("MainMenu");
            return;
        }
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

    public void setspeed(int modifier)
    {
        speed += 5.0f;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DeathObject")
        {
            Death();
        }
    }

    //private void OnControllerHit(ControllerColliderHit hit)
    //{
        //if(hit.point.z > transform.position.z + controller.radius)
        //{
            //Death();
        //}
    //}

    private void Death()
    {
        isDead = true;
        Debug.Log("dead");
        deathSound.Play();
        GetComponent<Score>().OnDeath();
    }
}
