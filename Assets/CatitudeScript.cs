using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatitudeScript : MonoBehaviour
{


    public float Catitude;

    public float NoiseLevel;
    public float SpookMod; //how likely is an event to spook you
    public float ZoomMod; //how likely kitteh is to start oomies

    public bool InNoise;
    public float distanceToVacuum;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Noise")
        {
            InNoise = true;
        }
    }
    

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Noise")
        {
            Vector3 dVector = transform.position - other.transform.position;
            distanceToVacuum = dVector.magnitude;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Noise")
        {
            InNoise = false;
        }
    }

}
