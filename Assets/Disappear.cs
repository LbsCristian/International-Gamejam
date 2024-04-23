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
    Collider2D thecollider;
    
    void Start()
    {
        playerSwitch = player.GetComponent<Switch>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        thecollider = GetComponent<Collider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSwitch.playerWorld==objectWorld)
        {
            mySpriteRenderer.enabled = true;
            thecollider.enabled = true;
        }
        else
        {

            mySpriteRenderer.enabled = false;
            thecollider.enabled = false;

        }

        if (transform.parent == player.transform)
        {
            objectWorld = playerSwitch.playerWorld;
        }
    }
}
