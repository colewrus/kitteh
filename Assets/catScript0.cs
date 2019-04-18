using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catScript0 : MonoBehaviour
{


    float H;
    float V;
    Vector3 MoveVector;
    public Vector3 MousePos; // returns the mouse position for rotating cat

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
    public Vector3 lookAtOffset;
    public float offsetX, offsetY;
    

    public Cinemachine.CinemachineVirtualCamera myCamera;
    public Cinemachine.CinemachineComposer myComposer;
    // Start is called before the first frame update
    void Start()
    {
        speed = walkSpeed;
        clickText.SetActive(false);
        lookAtStartingPos = lookAtObj.transform.position;
        Debug.Log("Difference: " + (transform.position - lookAtStartingPos));
        lookAtOffset = (transform.position - lookAtStartingPos);

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
            float screenPercentX = Mathf.Abs(MousePos.x / (Screen.width / 2));
            transform.Rotate(new Vector3(0, (-turnSpeed*screenPercentX)*Time.deltaTime, 0), Space.World);
        }else if(MousePos.x < -TurnTolerance)
        {
            float screenPercentX = Mathf.Abs(MousePos.x / (Screen.width / 2));
            transform.Rotate(new Vector3(0, (turnSpeed* screenPercentX)*Time.deltaTime, 0), Space.World);
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
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            jumpPower = 0;
         
        }

        Boop();
        LookControl();

        
        
        MoveVector = new Vector3(V, 0, -H) * speed;
        transform.Translate(MoveVector * Time.deltaTime);
    }


    void LookControl()
    {
       

        float screenPercentX = Mathf.Abs(MousePos.x / (Screen.width / 2));
        float screenPercentY = Mathf.Abs(MousePos.y / (Screen.height / 2));

      
        float zPos = Mathf.Clamp(MousePos.x, -offsetX * screenPercentX, offsetX * screenPercentX);
        float yPos = Mathf.Clamp(-MousePos.y, -offsetY * screenPercentY, offsetY * screenPercentY);

        myComposer = myCamera.GetCinemachineComponent<Cinemachine.CinemachineComposer>(); //adjust the look at component of the 
        myComposer.m_TrackedObjectOffset = new Vector3(0, yPos, zPos); ;
        
    }

    void Boop()
    {
        
        if (myobject != null)
        {
            clickText.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                myobject.GetComponent<CupScript>().Boop();
                myobject = null;
            }
            clickText.SetActive(false);
        }
    }



}
