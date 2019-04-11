using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catScript0 : MonoBehaviour
{


    float H;
    float V;
    Vector3 MoveVector;
    Vector3 MousePos; // returns the mouse position for rotating cat

    public float speed; //
    public float runSpeed; //
    public float crouchSpeed; //toggle?
    public float walkSpeed; //

    public float turnSpeed;

    float jumpPower;
    public float jumpMax;
    [Tooltip("Multiplies against Time.deltaTime to charge up jump power")]
    public float jumpChargeRate; 

    public Camera MainCam;
    public float TurnTolerance;


    public bool InNoise, action;

    public GameObject myobject; //temporary hold for the object to interact with
    public GameObject clickText;

    public Vector3 lookAtStartingPos;
    public GameObject lookAtObj;
    
   
    

    // Start is called before the first frame update
    void Start()
    {
        speed = walkSpeed;
        clickText.SetActive(false);
        lookAtStartingPos = lookAtObj.transform.position;
        Debug.Log("Difference: " + (transform.position - lookAtStartingPos));
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        MousePos = new Vector3(Screen.width / 2, Screen.height / 2, 0) - Input.mousePosition;
        



        //Rotation
        if(MousePos.x > TurnTolerance)
        {
            transform.Rotate(new Vector3(0, -turnSpeed, 0), Space.World);
        }else if(MousePos.x < -TurnTolerance)
        {
            transform.Rotate(new Vector3(0, turnSpeed, 0), Space.World);
        }

        //Run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }else if (Input.GetKey(KeyCode.LeftControl))
        {//Now crouch
            speed = crouchSpeed;
        }
        else
        {//Just walk
            speed = walkSpeed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(jumpPower < jumpMax)
                jumpPower += jumpChargeRate * Time.deltaTime;
           
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce((transform.forward*2) + new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            jumpPower = 0;
            Debug.Log("Should jump");
        }

        Boop();
 

        
        
        MoveVector = new Vector3(V, 0, -H) * speed;
        transform.Translate(MoveVector * Time.deltaTime);
    }


    void Boop()
    {
        
        if (myobject != null)
        {
            clickText.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("boop");
                myobject.GetComponent<CupScript>().Boop();
                myobject = null;
            }
            clickText.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Noise")
        {
            InNoise = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Noise")
        {
            InNoise = false;
        }
    }
}
