using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySpawn.spawnerScript.numberOfEnemies == 0)
        {
            Destroy(gameObject);
            return;
        }
    }
}
