using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerWorld;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerWorld == 1)
            {
                playerWorld = 2;
            }
            else if (playerWorld==2)
            {
                playerWorld = 1;
            }
        }
    }
}
