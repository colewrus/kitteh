using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccumScript : MonoBehaviour
{

    Vector3 Destination;
    Vector3 Direction;
    public float speed;
    public float turnamount, backupLength, moveTimer;
    float tick;
    bool reverse;

    


    // Start is called before the first frame update
    void Start()
    {
        tick = 0;
        reverse = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10, Color.blue);
        Debug.DrawRay(transform.position, transform.right * 10, Color.green);
        Debug.DrawRay(transform.position, transform.up * 10, Color.red);


        



        if (!reverse)
        {
            Direction = transform.forward * speed;
            transform.Translate(Direction * Time.deltaTime, Space.World);
        }
        else
        {
            Direction = transform.forward * -speed;
            transform.Translate(Direction * Time.deltaTime, Space.World);
            transform.Rotate(new Vector3(0, turnamount, 0) * Time.deltaTime, Space.World);
            if (tick < backupLength)
            {
                tick += 1 * Time.deltaTime;

            }
            else
            {
                tick = 0;
                reverse = false;
            }
        }
            



    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {

            Debug.Log("bump");
        }

        if (collision.transform.tag == "Furniture")
        {
            Debug.Log("furniture");
            reverse = true;
            tick = 0;
        }
    }
}
