using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    private const float eps = 6.67e-11f, mc = 6e11f;
    public float alpha = 50, r, p, e, a, m = 1, v = 1, k0,e0;
    public float phi = 0;

    // Start is called before the first frame update
    void Start()
    {
        r = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2) + Mathf.Pow(transform.position.z, 2));
        float temp = Mathf.Acos(Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.z, 2))/r);
        alpha += 90 - Mathf.Rad2Deg * temp;
        k0 = r * m * v;
        a = m * mc * eps;
        e0 = m * v * v / 2 - a / r;
        p = k0 * k0 / (m * a);
        e = Mathf.Sqrt(1+2*e0*k0*k0/(m*a*a));
    }

    // Update is called once per frame
    void Update()
    {
        phi+=k0/(m * r*r);
        //e = 0.9f;
        r = p / (1f + e * Mathf.Cos(phi * Mathf.Deg2Rad));
        transform.position = new Vector3(r * Mathf.Cos(phi * Mathf.Deg2Rad), r * Mathf.Sin(phi * Mathf.Deg2Rad), 0);
    }
}
