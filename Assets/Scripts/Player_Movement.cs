using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
public class Player_Movement : MonoBehaviour
{
    public static Player_Movement playerScript;
    public float speed = 32f;
    private Vector3 playerMovement;
    CharacterController Cr;
    public LayerMask groundLayer;
    public int playerX;
    public int playerY;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = this;
        Cr = GetComponent<CharacterController>();
    }
    //update called every frame
    private void Update()
    {
        //sets character controller y to 5 to help with collision
     Cr.transform.position = new Vector3(Cr.transform.position.x,5, Cr.transform.position.z);

        if(playerX < 0)
        {
          playerX = 0;
        }
        if(playerY < 0)
        {
          playerY = 0;
        }
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
            //calls the room has been changed
            if (wall.wallScript != null)
            {
                wall.wallScript.roomChange();
            }
            if (room.roomScript != null)
            {
                Debug.Log("room changed");
                room.roomScript.roomChange();
            }
            if (roomSpawn.roomScript != null)
            {
                if (room.roomScript.roomChanged == true)
                {
                    roomSpawn.roomScript.rSpawn();
                    room.roomScript.roomChanged = false;
                }
            }
            //subtracting one from roomX
            playerX--;
        }
        else if (other.name == "rightTrigger")
        {
            Debug.Log("right Trigger");
            //stops character controller from preventing tp
            Cr.enabled = false;
            Cr.transform.position = new Vector3(-69, 5, Cr.transform.position.z);
            Cr.enabled = true;
            //calls the room has been changed
            if (wall.wallScript != null)
            {
                wall.wallScript.roomChange();
            }
            if (room.roomScript != null)
            {
                Debug.Log("room changed");
                room.roomScript.roomChange();
            }
            if (roomSpawn.roomScript != null)
            {
                if (room.roomScript.roomChanged == true)
                {
                    roomSpawn.roomScript.rSpawn();
                    room.roomScript.roomChanged = false;
                }
            }
            //adding one to roomX
            playerX++;
        }
        else if (other.name == "topTrigger")
        {
            Debug.Log("top Trigger");
            //stops character controller from preventing tp
            Cr.enabled = false;
            Cr.transform.position = new Vector3(Cr.transform.position.x, 5, -20);
            Cr.enabled = true;
            //calls the room has been changed
            if (wall.wallScript != null)
            {
                wall.wallScript.roomChange();
            }
            if (room.roomScript != null)
            {
                Debug.Log("room changed");
                room.roomScript.roomChange();
            }
            if (roomSpawn.roomScript != null)
            {
                if (room.roomScript.roomChanged == true)
                {
                    roomSpawn.roomScript.rSpawn();
                    room.roomScript.roomChanged = false;
                }
            }
            //moving one room up(reversed because of 2d array)
            playerY--;

            //adding one to roomY
        }
        else if (other.name == "bottomTrigger")
        {
            Debug.Log("bottom Trigger");
            //stops character controller from preventing tp
            Cr.enabled = false;
            Cr.transform.position = new Vector3(Cr.transform.position.x, 5, 98);
            Cr.enabled = true;
            //calls the room has been changed
            if (wall.wallScript != null)
            {
                wall.wallScript.roomChange();
            }
            if (room.roomScript != null)
            {
                Debug.Log("room changed");
                room.roomScript.roomChange();
            }
            if (roomSpawn.roomScript != null)
            {
                if(room.roomScript.roomChanged == true)
                {
                    roomSpawn.roomScript.rSpawn();
                    room.roomScript.roomChanged = false;
                }
            }
            //moving one room down
            playerY++;
        }
    } 
}
        
