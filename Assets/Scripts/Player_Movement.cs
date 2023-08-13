using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 32f;
    private Vector3 playerMovement;
    CharacterController Cr;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        Cr = GetComponent<CharacterController>();
    }
    //update called every frame
    private void Update()
    {
        //sets character controller y to 5 to help with collision
     Cr.transform.position = new Vector3(Cr.transform.position.x,5, Cr.transform.position.z);
    }
    // Update is called set number of times per second 
    void FixedUpdate()
    {
        //player movement 

        //movement on the x axis is equal to the horizontal input, if left x = -1, if right = 1
        float xMove = Input.GetAxisRaw("Horizontal");
        //movement on the z axis is equal to the vertical input, if up y = 1, if down y = -1
        float zMove = Input.GetAxisRaw("Vertical");
        //gets the playermovement x and z by mutiplying the x and z move values by speed and Time.Deltatime for consistency when lagging
        playerMovement.x = xMove * speed * Time.deltaTime;
        playerMovement.z = zMove * speed * Time.deltaTime;
        //applies the movement to the player
        Cr.Move(playerMovement);
    }
    //player collision with triggers
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "leftTrigger")
        {
            Debug.Log("Left Trigger");
            Cr.enabled = false;
            Cr.transform.position = new Vector3(60, 5, Cr.transform.position.z);
            Cr.enabled = true;

            //subtracting one from roomX
        }
        else if (other.name == "rightTrigger")
        {
            Debug.Log("right Trigger");
            //stops character controller from preventing tp
            Cr.enabled = false;
            Cr.transform.position = new Vector3(-69, 5, Cr.transform.position.z);
            Cr.enabled = true;

            //adding one to roomX
        }
        else if (other.name == "topTrigger")
        {
            Debug.Log("top Trigger");
            //stops character controller from preventing tp
            Cr.enabled = false;
            Cr.transform.position = new Vector3(Cr.transform.position.x, 5, -20);
            Cr.enabled = true;

            //adding one to roomY
        }
        else if (other.name == "bottomTrigger")
        {
            Debug.Log("bottom Trigger");
            //stops character controller from preventing tp
            Cr.enabled = false;
            Cr.transform.position = new Vector3(Cr.transform.position.x, 5, 98);
            Cr.enabled = true;

            //subtracting one from roomY
        }

    }
   
}
        
