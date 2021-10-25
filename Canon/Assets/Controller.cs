using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    
    public float xD = 0, yD = 0, zD = 0;
    public float force = 10;
    // Start is called before the first frame update
    void Start()
    {
        /*Vector3 newRotation = new Vector3(xD, yD, zD);
        Vector3 f = newRotation.normalized * force;
        GetComponent<Rigidbody>().AddForce(f, ForceMode.Impulse);*/
    }

    void Aiming(InputValue rot)
    {
        Vector3 rotation = rot.Get<Vector3>();
    }

	// Update is called once per frame
	void FixedUpdate()
    {

    }
}
