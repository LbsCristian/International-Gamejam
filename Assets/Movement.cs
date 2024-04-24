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
    public float verticalInput;
    Vector2 movement;
    [SerializeField]
    BoxCollider2D pickupTrigger;
    Animator walkingAnimator;

    public LayerMask pickupable;
    ContactFilter2D coctactFilter;
    Collider2D pickupobject;
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        walkingAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        movement = new Vector2(horizontalInput, verticalInput).normalized*speed;
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(movement.x, movement.y, 0);

        
        if (horizontalInput == 1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (horizontalInput == -1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (verticalInput == -1)
        {
            walkingAnimator.SetBool("Movingvertically", true);
        }
        else
        {
            walkingAnimator.SetBool("Movingvertically", false);
        }
        
        

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
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
