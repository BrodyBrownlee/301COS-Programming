using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using Unity.VisualScripting;

public class enemySpawn : MonoBehaviour
{
    public static enemySpawn spawnerScript;

    public GameObject pfEnemy;
    public bool enemiesSpawned;
    public float numberOfEnemies = 0;//current enemy number
    public float maxNumEnemies = 10;//maximum number of enemies able to be spawned with right bracket

    private void Awake()
    {
        //creates an instance of the script which can be called in other classes
        spawnerScript = this;
        eSpawn();
        
    }
    // Update is called once per frame
    void Update()
    {   
        //for testing purposes 

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
    public void eSpawn()
    {
        var roomCoordinates = new Vector2Int(Player_Movement.playerScript.playerX, Player_Movement.playerScript.playerY);
        if (roomSpawn.roomScript.clearedRooms.Contains(roomCoordinates)) return;
        else
        {
            //finds all enemy spawn locations with the tags
            var enemies = GameObject.FindGameObjectsWithTag("enemySpawn");
            foreach (var enemySpawn in enemies)
            {
                GameObject newEnemy = Instantiate(pfEnemy);
                newEnemy.transform.position = enemySpawn.transform.position;
                numberOfEnemies++;
            }
            DeactivateEnemySpawnPoints();
        }
    }
    public void DeactivateEnemySpawnPoints()
    {
        // Deactivate all enemy spawn points
        var allSpawnPoints = GameObject.FindGameObjectsWithTag("enemySpawn");
        foreach (var spawnPoint in allSpawnPoints)
        {
            spawnPoint.SetActive(false);
        }
    }
}
