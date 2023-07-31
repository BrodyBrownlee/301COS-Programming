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
            GameObject newDoor = Instantiate(pfDoor);
            newDoor.transform.position = new Vector3(-80, 2, 45);
            newDoor.transform.localScale = new Vector3(10, 10, 40);     
    }
}
