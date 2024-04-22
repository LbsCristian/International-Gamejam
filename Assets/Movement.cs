using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    [SerializeField]
    float speed = 10;
    float horizontalInput;
    float verticalInput;
    Vector2 movement;
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = new Vector2(horizontalInput, verticalInput).normalized*speed;
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(movement.x,movement.y,0);

        
    }
}
