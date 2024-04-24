using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBoomerang : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Rigidbody2D rb;
    Collider2D objectCollider;
    bool thrown;
    public float throwtimer=0;
    int throwstrenght = 20;

    SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        objectCollider = GetComponent<Collider2D>();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)&&!thrown)
        {
            sr.enabled = true;
            throwtimer = 0;
            thrown = true;
            transform.position = player.transform.position;
            if (player.GetComponent<Movement>().verticalInput==0) 
            {
                rb.velocity = player.transform.right * -throwstrenght;
            }
            else
            {
                if (player.GetComponent<Movement>().verticalInput == 1)
                {
                    rb.velocity = Vector2.up * throwstrenght;
                }
                else
                {
                    rb.velocity = Vector2.down * throwstrenght;
                }
            }
            
          

        }
        if (thrown)
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z +300*Time.deltaTime);
            GetComponent<Collider2D>().enabled = true;
            //adds a force towards the player
            rb.AddForce((player.transform.position - transform.position)*250f*Time.deltaTime);
            throwtimer+=100*Time.deltaTime;
            if (Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) < 1 && throwtimer > 50)
            { 
                rb.velocity = new Vector2(0, 0);
                thrown = false;
                sr.enabled = false;
                GetComponent<Collider2D>().enabled = false;
            }
            if (throwtimer > 250)
            {

                
                rb.velocity=((player.transform.position - transform.position) * 10);
                GetComponent<Collider2D>().enabled = false;
                

            }
            
        }
    }
}
