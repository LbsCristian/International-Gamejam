using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Switch playerswitch;
    float appearTimer=0;
    SpriteRenderer sr;
    public float appearfade;
    Rigidbody2D rb;
    [SerializeField]
    float speed;
    [SerializeField]
    int invincibilityFrames = 0;
    void Start()
    {
        playerswitch = player.GetComponent<Switch>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = rb.velocity * 0.95f;
        if (invincibilityFrames > 0)
        {
            invincibilityFrames--;
        }
        sr.color =new Color(1f, 1f, 1f, ((appearTimer)/100));
        if (playerswitch.playerWorld == 2&&appearTimer<100)
        {
            rb.velocity = Vector2.zero;
            appearTimer+=100*Time.deltaTime;
            
            
            
        }
        
        else if(playerswitch.playerWorld==1&&appearTimer>0)
        {    
            rb.velocity = Vector2.zero;
            appearTimer -=Time.deltaTime*4;   
        }
        if (appearTimer > 100&&invincibilityFrames<1)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Boomer"&&invincibilityFrames<1)
        {   
            rb.AddForce(collision.gameObject.transform.right * 10,ForceMode2D.Impulse);
            invincibilityFrames=200;
        }
    }
}
