using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Vector3 v;

    // Start is called before the first frame update
    void Start()
    {
        v = new Vector3(0, transform.position.y, -transform.position.z) * 1.7f;
        GetComponent<Rigidbody>().AddForce(v, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = -transform.position.normalized;
        float lenght = transform.position.magnitude;
        float c = 6.67e-11f * 6e12f * GetComponent<Rigidbody>().mass / (lenght*lenght);
        Vector3 force = -transform.position.normalized * c*Time.fixedDeltaTime;
        GetComponent<Rigidbody>().AddForce(force,ForceMode.Impulse);
        



    }
}
