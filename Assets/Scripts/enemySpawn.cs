using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;

public class enemySpawn : MonoBehaviour
{
    public static enemySpawn spawnerScript;
    public GameObject pfEnemy;
    private GameObject enemyLoc;
    public float numberOfEnemies = 0;
    public float maxNumEnemies = 10;
    // Start is called before the first frame update
    void Start()
    {
        enemyLoc = GameObject.Find("enemySpawn");
        eSpawn();
    }
    private void Awake()
    {
        spawnerScript = this;
    }
    // Update is called once per frame
    void Update()
    {   
        if (numberOfEnemies < maxNumEnemies)
        {
            if (Input.GetKeyDown(KeyCode.RightBracket))
            {
                GameObject newEnemy = Instantiate(pfEnemy);
                newEnemy.transform.position = enemyLoc.transform.position;
                numberOfEnemies++;
            }
        }
    }
    private void eSpawn()
    {
        Debug.Log("Spawned!");
        GameObject newEnemy = Instantiate(pfEnemy);
        numberOfEnemies++;
        newEnemy.transform.position = enemyLoc.transform.position;
    }
}
