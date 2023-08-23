using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using Unity.VisualScripting;

public class enemySpawn : MonoBehaviour
{
    public static enemySpawn spawnerScript;

    public GameObject pfEnemy;
    private GameObject enemyLoc;
    public float numberOfEnemies = 0;//current enemy number
    public float maxNumEnemies = 10;//maximum number of enemies able to be spawned with right bracket
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        //creates an instance of the script which can be called in other classes
        spawnerScript = this;
        eSpawn();
    }
    // Update is called once per frame
    void Update()
    {   
        //if the number of enemies is not at the max
        if (numberOfEnemies < maxNumEnemies)
        {
            //if right bracket key is pressed
            if (Input.GetKeyDown(KeyCode.RightBracket))
            {
                eSpawn();
            }
        }
    }
    private void eSpawn()
    {

        var enemyLocation = GameObject.FindGameObjectsWithTag("enemySpawn");
        foreach(var enemySpawn in enemyLocation)
        {
            GameObject newEnemy = Instantiate(pfEnemy);
            newEnemy.transform.position = enemySpawn.transform.position;
            numberOfEnemies++;
        }
    }
}
