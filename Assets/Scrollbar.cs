using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrollbar : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    Slider theSlider;
    void Start()
    {
        theSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        theSlider.value = enemy.GetComponent<ChasePlayer>().appearTimer;
    }
}
