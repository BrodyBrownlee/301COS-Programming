using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawn : MonoBehaviour
{
    public static roomSpawn roomScript;

    public GameObject pfRoom;
    public GameObject pfDoor;
    public GameObject pfTrigger;
    public bool doorsSpawned;
    public bool roomClear;
    public bool triggerSpawned;
    public float doorNumber;
    private GameObject roomLoc;

    // Start is called before the first frame update
    void Start()
    {
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
                doorsSpawned = true;
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
        GameObject leftTrigger = Instantiate(pfTrigger);
        leftTrigger.transform.position = new Vector3(-80, 2, 45);
        leftTrigger.transform.localScale = new Vector3(10, 10, 40);
        GameObject rightTrigger = Instantiate(pfTrigger);
        rightTrigger.transform.position = new Vector3(70, 2, 35);
        rightTrigger.transform.localScale = new Vector3(10, 10, 40);
        GameObject topTrigger = Instantiate(pfTrigger);
        topTrigger.transform.position = new Vector3(-5, 2, 110);
        topTrigger.transform.localScale = new Vector3(20, 10, 10);
        topTrigger.transform.Rotate(180, 0, 0);
        GameObject bottomTrigger = Instantiate(pfTrigger);
        bottomTrigger.transform.position = new Vector3(-5, 2, -40);
        bottomTrigger.transform.localScale = new Vector3(20, 10, 10);
        bottomTrigger.transform.Rotate(180, 0, 0);
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
