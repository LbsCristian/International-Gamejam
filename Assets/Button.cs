using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    PolygonCollider2D pc;
    Collider2D[] results = new Collider2D[4];
    ContactFilter2D cc;
    public GameObject linkedObject;
    public bool isToggle;
    bool on;
    bool touching;
    SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PolygonCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            linkedObject.GetComponent<SpriteRenderer>().enabled = false;
            linkedObject.GetComponent<Collider2D>().enabled = false;
            sr.color = new Color(1, 0.5f, 1);

        }
        else
        {
            linkedObject.GetComponent<SpriteRenderer>().enabled = true;
            linkedObject.GetComponent<Collider2D>().enabled = true;
            sr.color = new Color(1, 1, 1);
        }

        if (pc.OverlapCollider(cc, results) != 0)
        {
            if (isToggle&&!touching)
            {
                touching = true;
                if (on)
                {
                    on = false;
                }
                else
                {
                    on = true;
                }
            }
            else
            {
                on = true;
            }
        

        }
        else
        {
            if (!isToggle)
            {
                on = false;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        touching = false;
    }
}
    

