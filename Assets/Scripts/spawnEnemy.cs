using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public GameObject pfEnemy;
    private GameObject enemyLoc;
    // Start is called before the first frame update
    void Start()
    {
        enemyLoc = GameObject.Find("enemySpawn");
        eSpawn();
    }

    // Update is called once per frame
    void Update()
    {

      
    }
    private void eSpawn()
    {
        Debug.Log("Spawned!");
        GameObject newEnemy = Instantiate(pfEnemy);
        newEnemy.transform.position = enemyLoc.transform.position;
    }
}
