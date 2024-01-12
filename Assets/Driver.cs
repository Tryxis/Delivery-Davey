using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float turnSpeed = 300f;
    [SerializeField] public float moveSpeed = 15f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 20f;
    

    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // - turnAmount makes the double negative a positive
        // Otherwise left and right are reversed
        transform.Rotate(0,0, -turnAmount);
        transform.Translate(0, moveAmount, 0);

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Speed Boost"))
        {
            moveSpeed = boostSpeed;
        }
    }
}
