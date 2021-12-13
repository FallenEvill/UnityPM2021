using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WALL : MonoBehaviour
{
    public int height = 10;
    public int widght = 10;

    public GameObject wallbrick;
    private GameObject[] wall;
    private float scale = 1f;
    // Start is called before the first frame update
    void Start()
    {
        int brc = height * widght;
        wall = new GameObject[brc];
        for (int i = 0; i < height; i++)
            for(int j = 1; j <= widght; j++)
            {
                wall[i*j] = Instantiate(wallbrick);
                wall[i * j].transform.position = new Vector3(-2, scale * j-scale/2, -4 + scale * i + scale / 8);
            }
        for (int i = 0; i < height; i++)
            for (int j = 1; j <= widght; j++)
			{
                if (i == 0)
                {
                    HingeJoint hw = wall[i * j].AddComponent(typeof(HingeJoint)) as HingeJoint;
                    hw.connectedBody = wall[i * j + 1].GetComponent<Rigidbody>();
                }
                else
                {
                    HingeJoint hw = wall[i * j].AddComponent(typeof(HingeJoint)) as HingeJoint;
                    hw.connectedBody = wall[i * j - 1].GetComponent<Rigidbody>();
                }
			}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
