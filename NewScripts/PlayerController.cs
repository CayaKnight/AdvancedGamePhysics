using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement speed
    public float speed;
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //keeping the player moving forward at all times
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //turning left when the left arrow is pressed
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.Rotate(0, -90, 0);
        //turning right when the right arrow is pressed
        if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.Rotate(0, 90, 0);
        //jumping if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
            rigidBody.AddForce(0, 5, 0, ForceMode.Impulse);
    }
}
