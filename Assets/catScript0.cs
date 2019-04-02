using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catScript0 : MonoBehaviour
{


    float H;
    float V;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        Debug.Log(H + ", " + V);
    }
}
