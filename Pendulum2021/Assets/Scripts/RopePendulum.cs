using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePendulum : MonoBehaviour
{
    public float angle = 0.0f;
    public float l = 5f;
    public float g = 9.8f;
    public float anglSpd = 0f;
    private float alpha;
    private float omega;
    private float amp;
    private float move;

    // Start is called before the first frame update
    void Start()
    {
        omega = Convert.ToSingle(Math.Sqrt(g / l));
        angle = Mathf.Deg2Rad * angle;
        if (anglSpd > 0)
            alpha = Mathf.Atan(angle * omega / anglSpd);
        else
            alpha = angle;
        amp = Mathf.Sqrt(Mathf.Sqrt(angle) + (Mathf.Sqrt(anglSpd) / Mathf.Sqrt(omega)));
        transform.position = new Vector3(l*Mathf.Sin(angle), -l*Mathf.Cos(alpha), 0);
    }

    // Update is called once per frame
    void Update()
    {
        move = Mathf.Sin(Time.time * omega + alpha) * amp;
        transform.position = new Vector3(Mathf.Sin(move)*l, -Mathf.Cos(move)*l, 0);

    }
}
