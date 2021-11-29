using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRot : MonoBehaviour
{
    public Vector3 v;
    private float timeDelay = 0.0f;
    private Quaternion q;
    private string label = "";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = new Vector3(60,10,-90).normalized;
        float c = 100;
        Vector3 force = dir * c * Time.fixedDeltaTime;
        GetComponent<Rigidbody>().AddTorque(force, ForceMode.Impulse);
        q = transform.rotation;
        label = q.ToString("f3");



    }

    void OnGUI()
    {
        GUI.skin.label.fixedHeight = 40;
        GUI.skin.label.fontSize = 24;
        GUI.Label(new Rect(10, 10, 400, 30), label);
    }
}
