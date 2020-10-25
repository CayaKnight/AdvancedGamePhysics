using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //keeps the player always moving forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //turns left when the left arrow is pressed
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.Rotate(0, -90, 0);
        //turns right when the right arrow is pressed
        if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.Rotate(0, 90, 0);
        //makes the player jump when the spce bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
    }
}
