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
        if (roomSpawn.roomScript.roomClear == false)
        {
            Destroy(gameObject);
            return;
        }
    }
}
