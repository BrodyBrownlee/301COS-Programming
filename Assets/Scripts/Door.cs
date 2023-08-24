using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //doors have been spawned
        roomSpawn.roomScript.doorsSpawned = true;
    }
    // Update is called once per frame
    void Update()
    {
        //if doors have been spawned and the room has been cleared
        if (roomSpawn.roomScript != null && roomSpawn.roomScript.roomClear == true && roomSpawn.roomScript.doorsSpawned == false)
        {
            //destroy the door objects
            Destroy(gameObject);
            //return to stop errors
            return;
        }
    }
}
