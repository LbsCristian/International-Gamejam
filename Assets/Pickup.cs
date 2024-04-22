using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        print(transform.parent);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PickedUp()
    { 
        transform.position = player.transform.position;
        transform.parent = player.transform;
    }
}
