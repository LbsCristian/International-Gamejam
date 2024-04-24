using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followplayer : MonoBehaviour
{
    public GameObject player;
    Switch playerworld;
    // Start is called before the first frame update
    void Start()
    {
        playerworld = player.GetComponent<Switch>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10);
        
    }
}
