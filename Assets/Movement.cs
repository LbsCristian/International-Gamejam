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
    [SerializeField]
    BoxCollider2D pickupTrigger;

    public LayerMask pickupable;
    ContactFilter2D coctactFilter;
    Collider2D pickupobject;
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
        rb.velocity = new Vector3(movement.x, movement.y, 0);
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Physics2D.OverlapBox(transform.position, new Vector2(1.5f, 1.5f),0,pickupable))
            {
                if (transform.childCount == 0)
                {
                    pickupobject = Physics2D.OverlapBox(transform.position, new Vector2(1.5f, 1.5f), 0, pickupable);
                    pickupobject.gameObject.GetComponent<Pickup>().PickedUp();
                }
                else
                {
                    gameObject.transform.DetachChildren();
                }
               
                
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(1.5f, 1.5f, 0));
    }
}
