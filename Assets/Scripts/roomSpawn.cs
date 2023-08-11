using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawn : MonoBehaviour
{
    //allows for calling of variables in other classes
    public static roomSpawn roomScript;

    public GameObject pfRoom;
    public GameObject pfDoor;
    public GameObject pfTrigger;
    //struct for the room coordinates which will be used to determine if a room has already been cleared.

    int[,] roomArray = new int[6, 4];

    public List<int> roomList;

    //bools for events on room clear and spawning of doors and triggers
    public bool doorsSpawned;
    public bool roomClear;
    public bool triggerSpawned;
    private GameObject roomLoc;

    // Start is called before the first frame update
    void Start()
    {
        //starts coords at 1,1
        //finds gameobject for room location 
        roomLoc = GameObject.Find("roomOrigin(1,1)");
        rSpawn();
    }
    void Awake()
    {
       //creates an instance of the class to allow calling of variables from other classes
        roomScript = this;
    }
    void Update()
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
        //if there are no doors(room has been cleared)
        if (doorsSpawned == false)
        {
            //if more enemies have spawned since they opened
            if (roomClear == false)
            {
                //spawn doors
                doorSpawn();
                //remove the room transition triggers
                triggerSpawned = false;
            }
        }
        //if triggers haven't been spawned
        if(triggerSpawned == false)
        {
            //if room is clear
            if (roomClear)
            {
                spawnTriggers();
                triggerSpawned = true;
            }
        }
    }
    //spawning the room based on the prefab selected
    private void rSpawn()
    {
        GameObject newRoom = Instantiate(pfRoom);
        //moving room to the position set by the roomLoc object
        newRoom.transform.position = roomLoc.transform.position;
    }
    //spawning triggers
    private void spawnTriggers()
    {
        //spawning and translating the top trigger
        GameObject topTrigger = Instantiate(pfTrigger);
        topTrigger.name = "topTrigger";
        topTrigger.transform.position = new Vector3(-5, 2, 110);
        topTrigger.transform.localScale = new Vector3(20, 10, 9);
        topTrigger.transform.Rotate(180, 0, 0);
        //spawning and translating the bottom trigger
        GameObject bottomTrigger = Instantiate(pfTrigger);
        bottomTrigger.name = "bottomTrigger";
        bottomTrigger.transform.position = new Vector3(-5, 2, -40);
        bottomTrigger.transform.localScale = new Vector3(20, 10, 9);
        bottomTrigger.transform.Rotate(180, 0, 0);
        //spawning and translating the left trigger
        GameObject leftTrigger = Instantiate(pfTrigger);
        leftTrigger.name = "leftTrigger";
        leftTrigger.transform.position = new Vector3(-80, 2, 35);
        leftTrigger.transform.localScale = new Vector3(9, 10, 20);
        //spawning and translating the right trigger
        GameObject rightTrigger = Instantiate(pfTrigger);
        rightTrigger.name = "rightTrigger";
        rightTrigger.transform.position = new Vector3(70, 2, 35);
        rightTrigger.transform.localScale = new Vector3(9, 10, 20);
        //return to stop multiple triggers spawning
        return;
    }
    private void doorSpawn()
    {
        //spawning and translating the left door
        GameObject leftDoor = Instantiate(pfDoor);
        leftDoor.transform.position = new Vector3(-80, 2, 35);
        leftDoor.transform.localScale = new Vector3(10, 10, 20);
        //spawning and translating the right door
        GameObject rightDoor = Instantiate(pfDoor);
        rightDoor.transform.position = new Vector3(70, 2, 35);
        rightDoor.transform.localScale = new Vector3(10, 10, 20);
        //spawning and translating the top door
        GameObject topDoor = Instantiate(pfDoor);
        topDoor.transform.position = new Vector3(-5, 2, 110);
        topDoor.transform.localScale = new Vector3(20, 10, 10);
        topDoor.transform.Rotate(180,0,0);
        //spawning and translating the bottom door
        GameObject bottomDoor = Instantiate(pfDoor);
        bottomDoor.transform.position = new Vector3(-5, 2, -40);
        bottomDoor.transform.localScale = new Vector3(20, 10, 10);
        bottomDoor.transform.Rotate(180, 0, 0);
        //return to stop multiple doors spawning
        return;
    }
}
