using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalTrapMovement : MonoBehaviour
{
    float timer = 0.0f;
    public float speed = 1.5f;
    public float maxTime = 9.5f;
    Vector3 movement = new Vector3(1, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            movement = -1.0f * movement;
            timer = 0.0f;
        }
        transform.position = transform.position + movement * speed * Time.deltaTime;
    }
}
