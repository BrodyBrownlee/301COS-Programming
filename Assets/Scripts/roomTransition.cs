using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(roomSpawn.roomScript != null)
        {
            //if the room has not been cleared
            if (roomSpawn.roomScript.roomClear == false)
            {
                //destroy triggers
                Destroy(gameObject);
                //return to avoid errors
                return;
            }
        }
    }
}
