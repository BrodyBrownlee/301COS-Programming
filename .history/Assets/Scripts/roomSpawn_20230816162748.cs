using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class roomSpawn : MonoBehaviour
{
    //allows for calling of variables in other classes
    public static roomSpawn roomScript;

    public GameObject startRoom;
    public GameObject treasureRoom;
    public GameObject bossRoom;
    public GameObject basicRoom;
    public GameObject basicRoom_2;
    public GameObject basicRoom_3;
    public GameObject basicRoom_4;


    public GameObject pfDoor;
    public GameObject pfTrigger;
    public GameObject pfWall;
    //array for the room coordinates which will be used to determine if a room has already been cleared.
    public int[,] roomArray;

    //list for the cleared rooms
    public List<int> roomList;
    //bools for events on room clear and spawning of doors and triggers
    public bool doorsSpawned;
    public bool roomClear;
    public bool triggerSpawned;
    public float roomValue;
    private GameObject roomLoc;
    //floor width and height
    int floorWidth;
    int floorHeight;

    // Start is called before the first frame update
    void Start()
    {
        //setting up the values for the rooms 
        try
        {
            //reading the values from the text file

            using (StreamReader reader = new StreamReader("Assets/Text_Files/map_layout.txt"))
            {
                //reading the height and width from the first two lines
                floorHeight = int.Parse(reader.ReadLine());
                floorWidth = int.Parse(reader.ReadLine());

                //sets size of array from the values
                roomArray = new int[floorHeight, floorWidth];

                //loop for floor height
                for (int i = 0; i < floorHeight; i++)
                {
                    //seperates the values splitting each line at a comma
                    string[] values = reader.ReadLine().Split(',');

                    //loop for the floor width
                    for (int h = 0; h < floorWidth; h++)
                    {
                        //sets the value of the coordinate in the array to the value from the text file
                        roomArray[i, h] = int.Parse(values[h]);
                        //display in the debug
                        /*   Debug.Log(values[h]);*/
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        /*   Debug.Log($"{roomArray[0,0].ToString()}{roomArray[0, 1].ToString()}{roomArray[0, 2].ToString()}{roomArray[0, 3].ToString()}");
           Debug.Log($"{roomArray[1, 0].ToString()}{roomArray[1, 1].ToString()}{roomArray[1, 2].ToString()}{roomArray[1, 3].ToString()}");
           Debug.Log($"{roomArray[2, 0].ToString()}{roomArray[2, 1].ToString()}{roomArray[2, 2].ToString()}{roomArray[2, 3].ToString()}");
           Debug.Log($"{roomArray[3, 0].ToString()}{roomArray[3, 1].ToString()}{roomArray[3, 2].ToString()}{roomArray[3, 3].ToString()}");
           Debug.Log($"{roomArray[4, 0].ToString()}{roomArray[4, 1].ToString()}{roomArray[4, 2].ToString()}{roomArray[4, 3].ToString()}");
           Debug.Log($"{roomArray[5, 0].ToString()}{roomArray[5, 1].ToString()}{roomArray[5, 2].ToString()}{roomArray[5, 3].ToString()}");
       */

        //finds gameobject for room location
        //setting player coordinates to the start room location
        for (int i = 0; i < floorHeight; i++)
        {
            //loop for the floor width
            for (int h = 0; h < floorWidth; h++)
            {
                if (roomArray[i, h] == 1)
                {
                    Player_Movement.playerScript.playerX = h;
                    Player_Movement.playerScript.playerY = i;
                }
            }
        }

        //finds gameobject for room location 
        roomLoc = GameObject.Find("roomOrigin(1,1)");
        roomValue = 1;
        rSpawn();
        doorSpawn();
    }
    //calls the instance the script is 
    void Awake()
    {
        //creates an instance of the class to allow calling of variables from other classes
        roomScript = this;
    }
    void Update()
    {
        if (Player_Movement.playerScript != null)
        {
            roomValue = roomArray[Player_Movement.playerScript.playerY, Player_Movement.playerScript.playerX];
        }

        if (enemySpawn.spawnerScript != null)
        {
            //if enemies are in the room
            if (enemySpawn.spawnerScript.numberOfEnemies > 0)
            {
                roomClear = false;
            }
            else
            {
                //if no enemies
                roomClear = true;
            }
        }
        //if room isn't clear
        if (!roomClear)
        {
            if (!doorsSpawned)
            {
                doorSpawn();
                doorsSpawned = true;
                triggerSpawned = false;
            }
        }
        //if triggers haven't been spawned
        //if room is clear
        if (roomClear)
        {
            if (!triggerSpawned)
            {
                spawnTriggers();
                triggerSpawned = true;
                doorsSpawned = false;
            }
        }
    }
    //spawning the room based on the prefab selected
    public void rSpawn()
    {
        //finding which room should be spawned based on the values set in the array
        if (roomValue == 1)
        {
            Debug.Log("Created Room 1");
            //moving room to the position set by the roomLoc object
            GameObject newRoom = Instantiate(startRoom);
            newRoom.transform.position = roomLoc.transform.position;
        }
        else if (roomValue == 2)
        {
            Debug.Log("Created Room 2");
            GameObject newRoom = Instantiate(treasureRoom);
            newRoom.transform.position = roomLoc.transform.position;
        }
        else if (roomValue == 3)
        {
            Debug.Log("Created Room 3");
            GameObject newRoom = Instantiate(bossRoom);
            newRoom.transform.position = roomLoc.transform.position;
        }
        else if (roomValue == 4)
        {
            Debug.Log("Created Room 4");
            GameObject newRoom = Instantiate(basicRoom);
            newRoom.transform.position = roomLoc.transform.position;
        }
        else if (roomValue == 5)
        {
            Debug.Log("Created Room 5");
            GameObject newRoom = Instantiate(basicRoom_2);
            newRoom.transform.position = roomLoc.transform.position;
        }
        else if (roomValue == 6)
        {
            Debug.Log("Created Room 6");
            GameObject newRoom = Instantiate(basicRoom_3);
            newRoom.transform.position = roomLoc.transform.position;
        }
        else if (roomValue == 7)
        {
            Debug.Log("Created Room 7");
            GameObject newRoom = Instantiate(basicRoom_4);
            newRoom.transform.position = roomLoc.transform.position;
        }
        else
        {
            Debug.Log("Created Error Room");
            GameObject newRoom = Instantiate(basicRoom_4);
            newRoom.transform.position = roomLoc.transform.position;
        }
    }
    //spawning triggers
    private void spawnTriggers()
    {
        //spawning and translating the top trigger
        GameObject topTrigger = Instantiate(pfTrigger);
        topTrigger.name = "topTrigger";
        topTrigger.transform.position = new Vector3(0, 2, 75);
        topTrigger.transform.localScale = new Vector3(20, 10, 9);
        topTrigger.transform.Rotate(180, 0, 0);
        //spawning and translating the bottom trigger
        GameObject bottomTrigger = Instantiate(pfTrigger);
        bottomTrigger.name = "bottomTrigger";
        bottomTrigger.transform.position = new Vector3(0, 2, -75);
        bottomTrigger.transform.localScale = new Vector3(20, 10, 9);
        bottomTrigger.transform.Rotate(180, 0, 0);
        //spawning and translating the left trigger
        GameObject leftTrigger = Instantiate(pfTrigger);
        leftTrigger.name = "leftTrigger";
        leftTrigger.transform.position = new Vector3(-75, 2, 0);
        leftTrigger.transform.localScale = new Vector3(9, 10, 20);
        //spawning and translating the right trigger
        GameObject rightTrigger = Instantiate(pfTrigger);
        rightTrigger.name = "rightTrigger";
        rightTrigger.transform.position = new Vector3(75, 2, 0);
        rightTrigger.transform.localScale = new Vector3(9, 10, 20);
        //return to stop multiple triggers spawning
        return;
    }
    public void doorSpawn()
    {
        return;
    }
    public void wallSpawn()
    {
        if (roomArray[Player_Movement.playerScript.playerX - 1, Player_Movement.playerScript.playerY] == 0 || roomArray[Player_Movement.playerScript.playerX - 1, Player_Movement.playerScript.playerY] == null)
        {
            leftWallSpawn();
          
        }
        else
        {
            //spawning and translating the left door
            GameObject leftDoor = Instantiate(pfDoor);
            leftDoor.transform.position = new Vector3(-75, 2, 0);
            leftDoor.transform.localScale = new Vector3(10, 10, 20);
           
        }

        if (roomArray[Player_Movement.playerScript.playerX + 1, Player_Movement.playerScript.playerY] == 0 || roomArray[Player_Movement.playerScript.playerX + 1, Player_Movement.playerScript.playerY] == null)
        {
            rightWallSpawn();
           
        }
        else
        {
            //spawning and translating the right door
            GameObject rightDoor = Instantiate(pfDoor);
            rightDoor.transform.position = new Vector3(75, 2, 0);
            rightDoor.transform.localScale = new Vector3(10, 10, 20);
          
        }
        if (roomArray[Player_Movement.playerScript.playerX, Player_Movement.playerScript.playerY - 1] == 0 || roomArray[Player_Movement.playerScript.playerX, Player_Movement.playerScript.playerY - 1] == null)
        {
            topWallSpawn();
       
        }
        else
        {
            //spawning and translating the top door
            GameObject topDoor = Instantiate(pfDoor);
            topDoor.transform.position = new Vector3(0, 2, 75);
            topDoor.transform.localScale = new Vector3(20, 10, 10);
            topDoor.transform.Rotate(180, 0, 0);
         
        }
        if (roomArray[Player_Movement.playerScript.playerX, Player_Movement.playerScript.playerY + 1] == 0 || roomArray[Player_Movement.playerScript.playerX, Player_Movement.playerScript.playerY + 1] == null)
        {
            bottomWallSpawn();
          
        }
        else
        {
            //spawning and translating the bottom door
            GameObject bottomDoor = Instantiate(pfDoor);
            bottomDoor.transform.position = new Vector3(0, 2, -75);
            bottomDoor.transform.localScale = new Vector3(20, 10, 10);
            bottomDoor.transform.Rotate(180, 0, 0);
        
        }
    }
    public void leftWallSpawn()
    {
        //spawning and translating the left door
        GameObject leftDoor = Instantiate(pfWall);
        leftDoor.transform.position = new Vector3(-75, 2, 0);
        leftDoor.transform.localScale = new Vector3(10, 10, 20);
    
    }
    public void rightWallSpawn()
    {
        //spawning and translating the right door
        GameObject rightDoor = Instantiate(pfWall);
        rightDoor.transform.position = new Vector3(75, 2, 0);
        rightDoor.transform.localScale = new Vector3(10, 10, 20);
    
    }
    public void topWallSpawn()
    {
        //spawning and translating the top wall
        GameObject topDoor = Instantiate(pfWall);
        topDoor.transform.position = new Vector3(0, 2, 75);
        topDoor.transform.localScale = new Vector3(20, 10, 10);
        topDoor.transform.Rotate(180, 0, 0);
     
    }
    public void bottomWallSpawn()
    {
        //spawning and translating the bottom door
        GameObject bottomDoor = Instantiate(pfWall);
        bottomDoor.transform.position = new Vector3(0, 2, -75);
        bottomDoor.transform.localScale = new Vector3(20, 10, 10);
        bottomDoor.transform.Rotate(180, 0, 0);
    
    }
}

