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
        if(roomSpawn.roomScript !=  null)
        {
            //if the room has been cleared
            if (roomSpawn.roomScript.roomClear == true)
            {
                //if doors have been spawned
                if (roomSpawn.roomScript.doorsSpawned == false)
                {
                    //destroy the door objects
                    Destroy(gameObject);
                    //return to stop errors
                    return;
                }
            }
        }
    }
}
