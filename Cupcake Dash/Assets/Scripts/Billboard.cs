using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    private SpriteRenderer sr;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera.transform.position, -Vector3.forward);
        
    }
}
