using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        roomSpawn.roomScript.doorsSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (roomSpawn.roomScript.roomClear == true)
        {
            if(roomSpawn.roomScript.doorsSpawned== true) {
                Destroy(gameObject);
                return;
            }
        }
    }
}
