using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBoomerang : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Rigidbody2D rb;
    Collider2D collider;
    bool thrown;
    float throwtimer=0;
    int throwstrenght = 20;

    SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
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
            rb.velocity=player.transform.right*throwstrenght;
          

        }
        if (thrown)
        {
            collider.enabled = true;
            //adds a force towards the player
            rb.AddForce((player.transform.position - transform.position)*1.5f);
            throwtimer+=100*Time.deltaTime;
            if (Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) < 1 && throwtimer > 50)
            { 
                rb.velocity = new Vector2(0, 0);
                thrown = false;
                sr.enabled = false;
                collider.enabled = false;
            }
            if (throwtimer > 200)
            {

                
                rb.velocity=((player.transform.position - transform.position) * 10);
                collider.enabled = false;
                

            }
            
        }
    }
}
