using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;

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
        //spawn an enemy on the enemySpawn position;
        enemyLoc = GameObject.Find("enemySpawn");
        eSpawn();
    }
    private void Awake()
    {
        //creates an instance of the script which can be called in other classes
        spawnerScript = this;
    }
    // Update is called once per frame
    void Update()
    {   
        //if the number of enemies is not at the max
        if (numberOfEnemies < maxNumEnemies)
        {
            //if right bracket is pressed
            if (Input.GetKeyDown(KeyCode.RightBracket))
            {
                eSpawn();
            }
        }
    }
    private void eSpawn()
    {
        //spawn an enemy on the enemyLoc object and add one to the number of enemies
        Debug.Log("Spawned!");
        GameObject newEnemy = Instantiate(pfEnemy);
        numberOfEnemies++;
        newEnemy.transform.position = enemyLoc.transform.position;
    }
}
