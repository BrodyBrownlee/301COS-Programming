using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawn : MonoBehaviour
{
    public GameObject pfRoom;
    public GameObject pfDoor;
    public float doorNumber;
    private GameObject roomLoc;

    // Start is called before the first frame update
    void Start()
    {
        doorNumber = 4;
        roomLoc = GameObject.Find("roomOrigin");
        rSpawn();
        doorSpawn();
    }
    private void rSpawn()
    {
        GameObject newRoom = Instantiate(pfRoom);
        newRoom.transform.position = roomLoc.transform.position;
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
    }
}
