using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    PolygonCollider2D pc;
    Collider2D[] results= new Collider2D[4];
    ContactFilter2D cc;
    public GameObject linkedObject;
    
    
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.OverlapCollider(cc,results) != 0)
        {
            linkedObject.GetComponent<SpriteRenderer>().enabled = false;
            linkedObject.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            linkedObject.GetComponent<SpriteRenderer>().enabled = true;
            linkedObject.GetComponent<Collider2D>().enabled = true;
        }
    }
    
}
