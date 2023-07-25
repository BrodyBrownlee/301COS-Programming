using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawn : MonoBehaviour
{
    public GameObject pfRoom;
    private GameObject roomLoc;

    // Start is called before the first frame update
    void Start()
    {
        roomLoc = GameObject.Find("roomOrigin");
        rSpawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void rSpawn()
    {
        GameObject newRoom = Instantiate(pfRoom);
        newRoom.transform.position = roomLoc.transform.position;
    }
}
