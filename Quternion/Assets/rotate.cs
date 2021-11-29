using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    private GameObject rotator;
    // Start is called before the first frame update
    void Start()
    {
        rotator = GameObject.Find("testsubj");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotator.transform.rotation, 1f);
    }
}
