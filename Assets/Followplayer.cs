using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followplayer : MonoBehaviour
{
    public GameObject player;
    Switch playerworld;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        playerworld = player.GetComponent<Switch>();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10);
        /*if (playerworld.playerWorld == 1)
        {
            cam.backgroundColor = new Color(173, 112, 160);


        }
        else
        {
            cam.backgroundColor = new Color(34, 44, 54);

        }
        */
    }
}
