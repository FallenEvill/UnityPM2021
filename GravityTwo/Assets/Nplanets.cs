using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nplanets : MonoBehaviour
{
    public int n = 5;
    public int mult = 10;
    public GameObject planet;
    public GameObject[] planets;
    public Vector3 v1, v2;
    public float m1, m2;
    private Rigidbody rb1;
    private Rigidbody rb2;
    // Start is called before the first frame update
    void Start()
    {
        planets = new GameObject[n];
        for (int i = 0; i < n; i++)
		{
            planets[i] = Instantiate(planet);
            planets[i].transform.position = new Vector3(Random.Range(-5f,5f)*i, Random.Range(-5f, 5f) * i, Random.Range(-5f, 5f) * i);
            rb1 = planets[i].GetComponent<Rigidbody>();
            v1 = new Vector3(0, rb1.transform.position.y+ Random.Range(-5f, 5f) * i, -rb1.transform.position.z) * 0.9f;
            rb1.AddForce(v1, ForceMode.VelocityChange);
        }
        for (int i = 0; i < n; i++)
            for (int j = i; j < n; j++)
            {
                if (i == j)
                    continue;
                rb1 = planets[i].GetComponent<Rigidbody>();
                rb2 = planets[j].GetComponent<Rigidbody>();
                Vector3 dir1 = -rb1.transform.position.normalized;
                Vector3 dir2 = -rb2.transform.position.normalized;
                float lenght = Mathf.Sqrt(Mathf.Pow(rb1.transform.position.x - rb2.transform.position.x, 2) + Mathf.Pow(rb1.transform.position.y - rb2.transform.position.y, 2) + Mathf.Pow(rb1.transform.position.z - rb2.transform.position.z, 2));
                float c = 100*rb1.mass * rb2.mass / (lenght * lenght);
                Vector3 force = -(rb1.transform.position - rb2.transform.position).normalized * c * Time.fixedDeltaTime;
                rb1.AddForce(force, ForceMode.Impulse);
                rb2.AddForce(-force, ForceMode.Impulse);
            }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for(int i = 0; i < n; i++)
            for(int j = i; j<n;j++)
			{
                if (i == j)
                    continue;
                rb1 = planets[i].GetComponent<Rigidbody>();
                rb2 = planets[j].GetComponent<Rigidbody>();
                Vector3 dir1 = -rb1.transform.position.normalized;
                Vector3 dir2 = -rb2.transform.position.normalized;
                float lenght = Mathf.Sqrt(Mathf.Pow(rb1.transform.position.x - rb2.transform.position.x, 2) + Mathf.Pow(rb1.transform.position.y - rb2.transform.position.y, 2) + Mathf.Pow(rb1.transform.position.z - rb2.transform.position.z, 2));
                float c = mult*rb1.mass * rb2.mass / (lenght * lenght);
                Vector3 force = -(rb1.transform.position - rb2.transform.position).normalized * c * Time.fixedDeltaTime;
                rb1.AddForce(force, ForceMode.Impulse);
                rb2.AddForce(-force, ForceMode.Impulse);
            }
    }
}
