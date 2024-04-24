using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchcolour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Switch playerworld;
    SpriteRenderer sr;

    void Start()
    {
        playerworld = player.GetComponent<Switch>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerworld.playerWorld == 2)
        {
            sr.color = new Color(1, 1, 1); 
        }
        else
        {
            sr.color = new Color(0.56f,0.6f,1);
        }
    }
}
