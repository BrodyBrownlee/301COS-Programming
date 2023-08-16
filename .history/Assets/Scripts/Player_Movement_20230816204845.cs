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
        //gets the player movement x and z by multiplying the x and z move values by speed and Time.Deltatime for consistency when lagging
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
            //subtracting one from roomX
            playerX--;
            Cr.enabled = false;
            Cr.transform.position = new Vector3(65, 5, Cr.transform.position.z);
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
                    if (Player_Movement.playerScript != null)
                    {
                        roomSpawn.roomScript.roomValue = roomSpawn.roomScript.roomArray[Player_Movement.playerScript.playerY, Player_Movement.playerScript.playerX];
                        roomSpawn.roomScript.rSpawn();
                        room.roomScript.roomChanged = false;
                    }
                }
            }
        }
        else if (other.name == "rightTrigger")
        {
            //adding one to roomX
            playerX++;
            Debug.Log("right Trigger");
            //stops character controller from preventing tp
            Cr.enabled = false;
            Cr.transform.position = new Vector3(-65, 5, Cr.transform.position.z);
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
                    if (Player_Movement.playerScript != null)
                    {
                        roomSpawn.roomScript.roomValue = roomSpawn.roomScript.roomArray[Player_Movement.playerScript.playerY, Player_Movement.playerScript.playerX];
                        roomSpawn.roomScript.rSpawn();
                        room.roomScript.roomChanged = false;
                    }
                 
                }
            }
        }
        else if (other.name == "topTrigger")
        {
            Debug.Log("top Trigger");
            //moving one room up(reversed because of 2d array)
            playerY--;
            //stops character controller from preventing tp
            Cr.enabled = false;
            Cr.transform.position = new Vector3(Cr.transform.position.x, 5, -65);
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
                    if (Player_Movement.playerScript != null)
                    {
                        roomSpawn.roomScript.roomValue = roomSpawn.roomScript.roomArray[Player_Movement.playerScript.playerY, Player_Movement.playerScript.playerX];
                        roomSpawn.roomScript.rSpawn();
                        room.roomScript.roomChanged = false;
                    }
                }
            }


            //adding one to roomY
        }
        else if (other.name == "bottomTrigger")
        {
            Debug.Log("bottom Trigger");
            //moving one room down
            playerY++;
            //stops character controller from preventing tp
            Cr.enabled = false;
            Cr.transform.position = new Vector3(Cr.transform.position.x, 5, 65);
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
                    if (Player_Movement.playerScript != null)
                    {
                        //sets the room value before changing the room so that the room is properly updated
                        roomSpawn.roomScript.roomValue = roomSpawn.roomScript.roomArray[Player_Movement.playerScript.playerY, Player_Movement.playerScript.playerX];
                        roomSpawn.roomScript.rSpawn();
                        room.roomScript.roomChanged = false;
                    }
                }
            }
        }
    } 
}
        
