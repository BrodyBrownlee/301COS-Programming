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
        
    }
    // Update is called set number of times per second 
    void FixedUpdate()
    {
        //sets character controller y to 5 to help with collision
        //movement on the x axis is equal to the horizontal input, if left x = -1, if right = 1
        float xMove = Input.GetAxisRaw("Horizontal");
        //movement on the z axis is equal to the vertical input, if up z = 1, if down z = -1
        float zMove = Input.GetAxisRaw("Vertical");
        //gets the player movement x and z by multiplying the x and z move values by speed and Time.Deltatime for consistency when lagging
        playerMovement.x = xMove * speed * Time.deltaTime;
        playerMovement.z = zMove * speed * Time.deltaTime;
        //applies the movement to the player
        Cr.Move(playerMovement);
        Cr.transform.position = new Vector3(Cr.transform.position.x, 5, Cr.transform.position.z);
    }
    //player collision with triggers
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "trigger")
        {

                GameController.gameController.roomChange();
            
            Cr.enabled = false;
            switch (other.name){

                case "rightTrigger":
                    //adding one to roomX
                    playerX++;
                    Debug.Log("right Trigger");
                    //stops character controller from preventing tp
                    Cr.transform.position = new Vector3(-65, 5, Cr.transform.position.z);
                    break;
                case "leftTrigger":
                    //adding one to roomX
                    playerX--;
                    Debug.Log("left Trigger");
                    //stops character controller from preventing tp
                    Cr.transform.position = new Vector3(65, 5, Cr.transform.position.z);
                    break;
                case "topTrigger":
                    //moving one room up(reversed because of 2d array)
                    playerY--;
                    Debug.Log("top Trigger");
                    //stops character controller from preventing tp
                    Cr.transform.position = new Vector3(Cr.transform.position.x, 5, -65);
                    break;
                case "bottomTrigger":
                    Debug.Log("bottom Trigger");
                    //moving one room down
                    playerY++;
                    //stops character controller from preventing tp
                    Cr.transform.position = new Vector3(Cr.transform.position.x, 5, 65);
                    break;
            }
            Cr.enabled = true;
            //calls the room has been changed
            if (roomSpawn.roomScript != null)
            {
                if (room.roomScript.roomChanged == true)
                {
                    roomSpawn.roomScript.roomValue = roomSpawn.roomScript.roomArray[Player_Movement.playerScript.playerY, Player_Movement.playerScript.playerX];
                    roomSpawn.roomScript.rSpawn();
                }
            }
        }
    } 
}
        
