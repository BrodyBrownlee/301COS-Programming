using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Unity.VisualScripting;

public class roomSpawn : MonoBehaviour
{
    //allows for calling of variables in other classes
    public static roomSpawn roomScript;
    //list of prefabs for rooms
    public GameObject startRoom;
    public GameObject treasureRoom;
    public GameObject bossRoom;
    public GameObject basicRoom;
    public GameObject basicRoom_2;
    public GameObject basicRoom_3;
    public GameObject basicRoom_4;
    //creates prefabs for spawnable doors, triggers and walls for the rooms
    public GameObject pfDoor;
    public GameObject pfTrigger;
    public GameObject pfWall;
    //prefabs for miniMap
    public GameObject pfRegularRoom;
    public GameObject pfTreasureRoom;
    public GameObject pfBossRoom;
    public GameObject pfCurrentRoom;
    public GameObject pfBlankRoom;

    //map layout text file
    public TextAsset mapLayout;
    string[] mapData;
    int dataLine = 0;
    //array for the room coordinates which will be used to determine if a room has already been cleared.
    public int[,] roomArray;

    //list for the cleared rooms
    public List<int> roomList;

    //bool for events on room clear and spawning of doors and triggers
    public bool doorsSpawned;
    public bool roomClear;
    public bool triggerSpawned;
    public float roomValue;
    private GameObject roomLoc;

    //floor width and height
    int floorWidth;
    int floorHeight;
    //start room
    Vector2Int startingRoom;
    int startingRoomX;
    int startingRoomY;

    public List<Vector2Int> clearedRooms = new List<Vector2Int>();

    // Start is called before the first frame update
    void Start()
    {

        //setting up the values for the rooms 
        try
        {
            mapData = mapLayout.text.Split(Environment.NewLine);

            while (dataLine < mapData.Length)
            {
                //reading the values from the text file

                //reading the height and width from the first two lines
                floorHeight = int.Parse(mapData[dataLine++]);
                floorWidth = int.Parse(mapData[dataLine++]);

                //sets size of array from the values
                roomArray = new int[floorHeight, floorWidth];

                //loop for floor height
                for (int i = 0; i < floorHeight; i++)
                {
                    //separates the values splitting each line at a comma
                    string[] values = mapData[dataLine++].Split(',');

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
            drawMiniMap();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    
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
        //finds game object for room location 
        roomLoc = GameObject.Find("roomOrigin(1,1)");
        if (Player_Movement.playerScript != null)
        {
            roomValue = roomArray[Player_Movement.playerScript.playerY, Player_Movement.playerScript.playerX];
        }
        rSpawn();
        doorSpawn();
    }
    //calls the instance the script is 
    void Awake()
    {
        //creates an instance of the class to allow calling of variables from other classes
        roomScript = this;
        roomClear = true;
        doorsSpawned = false;

       
    }
    void Update()
    {
        if (enemySpawn.spawnerScript != null)
        {
            //if enemies are in the room
            if (enemySpawn.spawnerScript.numberOfEnemies > 0 )
            {
                roomClear = false;
            }
            else
            {
                var roomCoordinates = new Vector2Int(Player_Movement.playerScript.playerX, Player_Movement.playerScript.playerY);
                if(!clearedRooms.Contains(roomCoordinates))
                {
                    clearedRooms.Add(roomCoordinates);
                }
                //if no enemies
                roomClear = true;
                doorsSpawned = false;
            }
        }
        //if room isn't clear
        if (!roomClear && !doorsSpawned)
        {
                doorSpawn();
                doorsSpawned = true;
                triggerSpawned = false;
        }
        //if triggers haven't been spawned
        //if room is clear
        if (roomClear && !triggerSpawned)
        {
                spawnTriggers();
                triggerSpawned = true;
                doorsSpawned = false;
        }
      
    }
    //spawning the room based on the prefab selected
    public void rSpawn()
    {
        var roomCoordinates = new Vector2Int(Player_Movement.playerScript.playerX, Player_Movement.playerScript.playerY);
        if (clearedRooms.Contains(roomCoordinates))
        {
           /* triggerSpawned = false;*/
        }
        if (enemySpawn.spawnerScript != null)
        {
            enemySpawn.spawnerScript.DeactivateEnemySpawnPoints();
        }

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
        wallSpawn();
    }
    //spawning triggers
    public void spawnTriggers()
    {
        //checking if the value of the room in a certain direction exists(this is the same for all spawn methods so won't repeat comment
        if (roomArray[Player_Movement.playerScript.playerY, Player_Movement.playerScript.playerX - 1] != 0)
        {
            leftTriggerSpawn();
        }
        if (roomArray[Player_Movement.playerScript.playerY, Player_Movement.playerScript.playerX + 1] != 0)
        {
            rightTriggerSpawn();
        }
        if (roomArray[Player_Movement.playerScript.playerY - 1, Player_Movement.playerScript.playerX] != 0)
        {
            topTriggerSpawn();
        }
        if (roomArray[Player_Movement.playerScript.playerY + 1, Player_Movement.playerScript.playerX] != 0)
        {
            bottomTriggerSpawn();
        }
    }
    //spawning doors
    public void doorSpawn()
    {
        if (roomArray[Player_Movement.playerScript.playerY, Player_Movement.playerScript.playerX - 1] != 0)
        {
            leftDoorSpawn();
        }
        if (roomArray[Player_Movement.playerScript.playerY, Player_Movement.playerScript.playerX + 1] != 0)
        {
            rightDoorSpawn();
        }
        if (roomArray[Player_Movement.playerScript.playerY - 1, Player_Movement.playerScript.playerX] != 0)
        {
            topDoorSpawn();
        }
        if (roomArray[Player_Movement.playerScript.playerY + 1, Player_Movement.playerScript.playerX] != 0)
        {
            bottomDoorSpawn();
        }
    }
    public void wallSpawn()
    {
        if (roomArray[Player_Movement.playerScript.playerY, Player_Movement.playerScript.playerX - 1] == 0)
        {
            leftWallSpawn();
        }
        if (roomArray[Player_Movement.playerScript.playerY, Player_Movement.playerScript.playerX + 1] == 0)
        {
            rightWallSpawn();
        }
        if (roomArray[Player_Movement.playerScript.playerY - 1, Player_Movement.playerScript.playerX] == 0)
        {
            topWallSpawn();
        }
        if (roomArray[Player_Movement.playerScript.playerY + 1, Player_Movement.playerScript.playerX] == 0)
        {
            bottomWallSpawn();
        }
    }
    //spawning specific objects based on which sides need them
    public void leftDoorSpawn()
    {
        //spawning and translating the left door
        GameObject leftDoor = Instantiate(pfDoor);
        leftDoor.transform.position = new Vector3(-75, 2, 0);
        leftDoor.transform.localScale = new Vector3(10, 10, 20);
    }
    public void rightDoorSpawn()
    {
        //spawning and translating the right door
        GameObject rightDoor = Instantiate(pfDoor);
        rightDoor.transform.position = new Vector3(75, 2, 0);
        rightDoor.transform.localScale = new Vector3(10, 10, 20);
    }
    public void topDoorSpawn()
    {
        //spawning and translating the top door
        GameObject topDoor = Instantiate(pfDoor);
        topDoor.transform.position = new Vector3(0, 2, 75);
        topDoor.transform.localScale = new Vector3(20, 10, 10);
        topDoor.transform.Rotate(180, 0, 0);
    }
    public void bottomDoorSpawn()
    {
        //spawning and translating the bottom door
        GameObject bottomDoor = Instantiate(pfDoor);
        bottomDoor.transform.position = new Vector3(0, 2, -75);
        bottomDoor.transform.localScale = new Vector3(20, 10, 10);
        bottomDoor.transform.Rotate(180, 0, 0);
    }
    public void leftTriggerSpawn()
    {
        //spawning and translating the left trigger
        GameObject leftTrigger = Instantiate(pfTrigger);
        leftTrigger.name = "leftTrigger";
        leftTrigger.transform.position = new Vector3(-75, 2, 0);
        leftTrigger.transform.localScale = new Vector3(9, 10, 20);
    }
    public void rightTriggerSpawn()
    {
        //spawning and translating the right trigger
        GameObject rightTrigger = Instantiate(pfTrigger);
        rightTrigger.name = "rightTrigger";
        rightTrigger.transform.position = new Vector3(75, 2, 0);
        rightTrigger.transform.localScale = new Vector3(9, 10, 20);
        //return to stop multiple triggers spawning
    }
    public void topTriggerSpawn()
    {
        //spawning and translating the top trigger
        GameObject topTrigger = Instantiate(pfTrigger);
        topTrigger.name = "topTrigger";
        topTrigger.transform.position = new Vector3(0, 2, 75);
        topTrigger.transform.localScale = new Vector3(20, 10, 9);
        topTrigger.transform.Rotate(180, 0, 0);
    }
    public void bottomTriggerSpawn()
    {
        //spawning and translating the bottom trigger
        GameObject bottomTrigger = Instantiate(pfTrigger);
        bottomTrigger.name = "bottomTrigger";
        bottomTrigger.transform.position = new Vector3(0, 2, -75);
        bottomTrigger.transform.localScale = new Vector3(20, 10, 9);
        bottomTrigger.transform.Rotate(180, 0, 0);
    }
    public void leftWallSpawn()
    {
        //spawning and translating the left door
        GameObject leftWall = Instantiate(pfWall);
        leftWall.name = "leftWall";
        leftWall.transform.position = new Vector3(-75, 2, 0);
        leftWall.transform.localScale = new Vector3(10, 10, 20);
    }
    public void rightWallSpawn()
    {
        //spawning and translating the right door
        GameObject rightWall = Instantiate(pfWall);
        rightWall.name = "rightWall";
        rightWall.transform.position = new Vector3(75, 2, 0);
        rightWall.transform.localScale = new Vector3(10, 10, 20);
    }
    public void topWallSpawn()
    {
        //spawning and translating the top wall
        GameObject topWall = Instantiate(pfWall);
        topWall.name = "topWall";
        topWall.transform.position = new Vector3(0, 2, 75);
        topWall.transform.localScale = new Vector3(20, 10, 10);
        topWall.transform.Rotate(180, 0, 0);
    }
    public void bottomWallSpawn()
    {
        //spawning and translating the bottom door
        GameObject bottomWall = Instantiate(pfWall);
        bottomWall.name = "bottomWall";
        bottomWall.transform.position = new Vector3(0, 2, -75);
        bottomWall.transform.localScale = new Vector3(20, 10, 10);
        bottomWall.transform.Rotate(180, 0, 0);
    }
    //drawning the minimap method 
    public void drawMiniMap()
    {
        //destroys the previous minimap
        var miniMapIcons = GameObject.FindGameObjectsWithTag("miniMap");
        foreach (var miniMapIcon in miniMapIcons)
        {
            Destroy(miniMapIcon);
        }
        //creates the new one using for loops and the player coordinates 
        for (int i = 0; i < floorHeight; i++)
        {
            for (int h = 0; h < floorWidth; h++)
            {
                if (roomArray[i, h] == 1)
                {
                    startingRoomX = h;
                    startingRoomY = i;
                    startingRoom = new Vector2Int(startingRoomX,startingRoomY);
                   
                }
                //instantiates object based on the room type returned from the roomtype method
                GameObject miniMapRoom = Instantiate(roomType(i, h));
                miniMapRoom.transform.position = new Vector3(95 + h * 6, 0, 70 - i * 6); // Calculate position based on i and h
            }
        }
    }
    private GameObject roomType(int row, int col)
    {

        //making current room the spawn room, when the game first loads
        if (roomArray[row, col] == 1 && Player_Movement.playerScript.playerX == 0 && Player_Movement.playerScript.playerY == 0)
        {
            return pfCurrentRoom;
        }
        //depending on the value of the room return a specific icon, and if the player is on the current coordinate return the current room icon 
        if (Player_Movement.playerScript.playerX == col && Player_Movement.playerScript.playerY == row && roomArray[row,col] != 0) 
        {
            return pfCurrentRoom;
        }
        else if (roomArray[row, col] == 3)
        {
            return pfBossRoom;
        }
        else if (roomArray[row, col] == 2)
        {
            return pfTreasureRoom;
        }
        if(roomArray[row, col] == 0)
        {
            return pfBlankRoom;
        }
        return pfRegularRoom; // Default return value
    }
}