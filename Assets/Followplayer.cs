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
        if (playerworld.playerWorld == 1)
        {
            cam.backgroundColor = new Color(0.173f, 0.112f, 0.160f);


        }
        else
        {
            cam.backgroundColor = new Color(0.34f, 0.44f, 0.54f);

        }
    }
}
