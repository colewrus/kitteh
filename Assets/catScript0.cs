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

    // Start is called before the first frame update
    void Start()
    {
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        MousePos = new Vector3(Screen.width / 2, Screen.height / 2, 0) - Input.mousePosition;

        if(MousePos.x > TurnTolerance)
        {
            transform.Rotate(new Vector3(0, -turnSpeed, 0), Space.World);
        }else if(MousePos.x < -TurnTolerance)
        {
            transform.Rotate(new Vector3(0, turnSpeed, 0), Space.World);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = crouchSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(jumpPower < jumpMax)
                jumpPower += jumpChargeRate * Time.deltaTime;
            Debug.Log(jumpPower);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce((transform.forward*2) + new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            jumpPower = 0;
            Debug.Log("Should jump");
        }
        

        

        
        MoveVector = new Vector3(V, 0, -H) * speed;
        transform.Translate(MoveVector * Time.deltaTime);
    }
}
