using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour
{

    public GameObject brokenCup;
    public bool interactable;
    public Material [] mats;

    public GameObject[] cupPieces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Boop()
    {
        
        for(int i=0; i<cupPieces.Length; i++)
        {
            cupPieces[i].GetComponent<MeshRenderer>().material = mats[0];
            cupPieces[i].GetComponent<Rigidbody>().isKinematic = false;
        }
        //brokenCup.SetActive(true);
        //this.gameObject.GetComponent<MeshRenderer>().enabled = false; //look like it disappears
        this.GetComponent<BoxCollider>().enabled = false; //don't have a trigger for cat to find
        
        //remove the assignment to cat, place this in the cat's Boop function

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            interactable = true;
            other.GetComponent<catScript0>().myobject = this.gameObject;
            for (int i = 0; i < cupPieces.Length; i++)
            {
                cupPieces[i].GetComponent<MeshRenderer>().material = mats[1];
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<catScript0>().myobject = null;
            interactable = false;
            for (int i = 0; i < cupPieces.Length; i++)
            {
                cupPieces[i].GetComponent<MeshRenderer>().material = mats[0];
            }
            
        }
    }
}
