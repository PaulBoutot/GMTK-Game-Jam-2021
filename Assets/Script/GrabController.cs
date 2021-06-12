using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    //Variables the tutorial said to use
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    public bool isHolding;
    public bool holdKey;
    public float throwforce;

    //run every frame
    void Update()
    {
        //invisible grabby hand variable
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        
        //Are within grabbing distance of box
        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {

            //ye. I want grab
            if (Input.GetKeyDown(KeyCode.G))
            {
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                isHolding = true;                
            }

            //no i no near box
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

            }

            
        }

        //i want to yeet
        if (Input.GetKeyUp(KeyCode.G) && isHolding)
        {
            //grabCheck.collider.gameObject.transform.parent = null;
            yeetTime();

        }

    }

    //YEET(not working)
    void yeetTime()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        print("yeet");
        //grabCheck.collider.gameObject.transform.parent = boxHolder;
        grabCheck.collider.gameObject.transform.parent = null;
        //grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
    }

}
