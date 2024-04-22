using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    // Start is called before the first frame update
    public int objectWorld;
    public GameObject player;
    Switch playerSwitch;

    SpriteRenderer mySpriteRenderer;
    BoxCollider2D boxCollider2D;
    
    void Start()
    {
        playerSwitch = player.GetComponent<Switch>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSwitch.playerWorld==objectWorld)
        {
            mySpriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
        }
        else
        {

            mySpriteRenderer.enabled = false;
            boxCollider2D.enabled = false;

        }
    }
}
