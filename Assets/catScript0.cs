using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catScript0 : MonoBehaviour
{


    float H;
    float V;
    Vector3 MoveVector;
    Vector3 MousePos;
    public float speed;
    public Camera MainCam;
    public float TurnTolerance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        MousePos = new Vector3(Screen.width / 2, Screen.height / 2, 0) - Input.mousePosition;

        if(MousePos.x > TurnTolerance)
        {
            transform.Rotate(new Vector3(0, -1, 0), Space.World);
        }else if(MousePos.x < -TurnTolerance)
        {
            transform.Rotate(new Vector3(0, 1, 0), Space.World);
        }
       
        

        

        Debug.Log(MousePos + " Center " + (Screen.width/2) + ", " + (Screen.height/2));
        MoveVector = new Vector3(V, 0, -H) * speed;
        transform.Translate(MoveVector * Time.deltaTime);
    }
}
