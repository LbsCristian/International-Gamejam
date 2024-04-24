using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Switch playerswitch;
    public float appearTimer=0;
    SpriteRenderer sr;
    [SerializeField]
    Animator Animator;
    
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
        if (player.transform.position.x > transform.position.x)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        rb.velocity = rb.velocity * 0.95f;
        if (invincibilityFrames > 0)
        {
            invincibilityFrames--;
        }
        sr.color =new Color(1f, 1f, 1f, ((appearTimer)/100));
        if (playerswitch.playerWorld == 2&&appearTimer<100)
        {
            rb.velocity = Vector2.zero;
            appearTimer+=5*Time.deltaTime;
            Animator.speed = 0;
            
            
            
            
            
        }
        
        else if(playerswitch.playerWorld==1&&appearTimer>0)
        {    
            rb.velocity = Vector2.zero;
            appearTimer -=Time.deltaTime*4;
            Animator.speed = 0;
            
        }
        if (appearTimer > 100&&invincibilityFrames<1)
        {
            Animator.speed = 1f;
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
        if (collision.gameObject.name == "Player" && invincibilityFrames < 1&&appearTimer>=100)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
