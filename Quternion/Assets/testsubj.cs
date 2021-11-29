using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testsubj : MonoBehaviour
{
    private int timePassed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timePassed == 100)
        {
            transform.rotation = Random.rotation;
            timePassed = 0;
        }
            timePassed++;
    }


}
