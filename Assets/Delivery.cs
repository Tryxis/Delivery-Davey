using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class Delivery : MonoBehaviour
{
    bool packagePickedUp;
    public Driver driver;

    [SerializeField] float destroyTime = 0.5f;
    [SerializeField] Color32 packagePickedUpColour = new Color32(1,1,1,1);
    [SerializeField] Color32 packageNotPickedUpColour = new Color32(1,1,1,1);

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        
    }  
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision" );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Package") && !packagePickedUp)
        {
            Debug.Log("Package collected");
            packagePickedUp = true;

            spriteRenderer.color = packagePickedUpColour;
            Debug.Log("Colour changed");

            Destroy(other.gameObject, destroyTime);
            Debug.Log("Package destroyed");

        } 

        if(other.CompareTag("Customer") && packagePickedUp == true)
        {
            Debug.Log("Package delivered");
            packagePickedUp = false;
            spriteRenderer.color = packageNotPickedUpColour;
            driver.moveSpeed = 15f;
            Debug.Log("Speed reset");
        }
    }
}
