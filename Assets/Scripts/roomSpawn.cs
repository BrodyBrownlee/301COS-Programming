using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawn : MonoBehaviour
{
    public static roomSpawn roomScript;

    public GameObject pfRoom;
    public GameObject pfDoor;
    public GameObject pfTrigger;
    
    public struct roomCoords
    {
        public float roomX;
        public float roomY;
    }
    public roomCoords roomCoordinates;

    public List<roomCoords> roomList;

    public bool doorsSpawned;
    public bool roomClear;
    public bool triggerSpawned;
    public float doorNumber;
    private GameObject roomLoc;

    // Start is called before the first frame update
    void Start()
    {
        roomCoordinates.roomX = 0;
        roomCoordinates.roomY = 0;

        doorNumber = 4;
        roomLoc = GameObject.Find("roomOrigin");
        rSpawn();
     
    }
    void Awake()
    {
       
        roomScript = this;
    }
    void Update()
    {
        if (enemySpawn.spawnerScript.numberOfEnemies > 0)
        {
            roomClear = false;
        }
        else
        {
            roomClear = true;
        }
        if (doorsSpawned == false)
        {
            if (roomClear == false)
            {
                doorSpawn();
                triggerSpawned = false;
            }
        }
        if(triggerSpawned == false)
        {
            if (roomClear)
            {
                spawnTriggers();
                triggerSpawned = true;
            }
        }
    }
    private void rSpawn()
    {
        GameObject newRoom = Instantiate(pfRoom);
        newRoom.transform.position = roomLoc.transform.position;
    }
    private void spawnTriggers()
    {
        GameObject topTrigger = Instantiate(pfTrigger);
        topTrigger.name = "topTrigger";
        topTrigger.transform.position = new Vector3(-5, 2, 110);
        topTrigger.transform.localScale = new Vector3(20, 10, 9);
        topTrigger.transform.Rotate(180, 0, 0);

        GameObject bottomTrigger = Instantiate(pfTrigger);
        bottomTrigger.name = "bottomTrigger";
        bottomTrigger.transform.position = new Vector3(-5, 2, -40);
        bottomTrigger.transform.localScale = new Vector3(20, 10, 9);
        bottomTrigger.transform.Rotate(180, 0, 0);
      
        GameObject leftTrigger = Instantiate(pfTrigger);
        leftTrigger.name = "leftTrigger";
        leftTrigger.transform.position = new Vector3(-80, 2, 35);
        leftTrigger.transform.localScale = new Vector3(9, 10, 20);
      
        GameObject rightTrigger = Instantiate(pfTrigger);
        rightTrigger.name = "rightTrigger";
        rightTrigger.transform.position = new Vector3(70, 2, 35);
        rightTrigger.transform.localScale = new Vector3(9, 10, 20);
        return;
    }
    private void doorSpawn()
    {
        GameObject leftDoor = Instantiate(pfDoor);
        leftDoor.transform.position = new Vector3(-80, 2, 45);
        leftDoor.transform.localScale = new Vector3(10, 10, 40);     
        GameObject rightDoor = Instantiate(pfDoor);
        rightDoor.transform.position = new Vector3(70, 2, 35);
        rightDoor.transform.localScale = new Vector3(10, 10, 40);
        GameObject topDoor = Instantiate(pfDoor);
        topDoor.transform.position = new Vector3(-5, 2, 110);
        topDoor.transform.localScale = new Vector3(20, 10, 10);
        topDoor.transform.Rotate(180,0,0);
        GameObject bottomDoor = Instantiate(pfDoor);
        bottomDoor.transform.position = new Vector3(-5, 2, -40);
        bottomDoor.transform.localScale = new Vector3(20, 10, 10);
        bottomDoor.transform.Rotate(180, 0, 0);
        return;
    }
}
