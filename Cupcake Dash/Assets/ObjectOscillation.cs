using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOscillation : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(0f, 0f, 0f);

    float movementFactor;

    [SerializeField] float period = 4f;

    Vector3 startingpos;
    // Start is called before the first frame update
    void Start()
    {
        startingpos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= 0f) { return; }

        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSineWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingpos + offset;
    }
}
