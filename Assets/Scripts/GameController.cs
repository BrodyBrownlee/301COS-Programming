using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    public bool gameEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        gameController = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player_HP.playerHPScript.HP <= 0 && !gameEnd)
        {
            gameOver();
            gameEnd = true;
        }
    }
    public void gameOver()
    {
        Debug.Log("Game Over");
    }
    public void roomChange()
    {
        var enemySpawns = GameObject.FindGameObjectsWithTag("enemySpawn");
        foreach (var enemy in enemySpawns)
        {
            Destroy(enemy);
        }
        Debug.Log("wall destroyed");
        var walls = GameObject.FindGameObjectsWithTag("blockingDoors");
        foreach (var wall in walls)
        {
            Destroy(wall);
        }
        var projectiles = GameObject.FindGameObjectsWithTag("projectile");
        foreach (var projectile in projectiles)
        {
            Destroy(projectile);
        }

        var triggers = GameObject.FindGameObjectsWithTag("trigger");
        foreach(var trigger in triggers )
        {
            Destroy(trigger);
        }
        roomSpawn.roomScript.triggerSpawned = false;
        room.roomScript.roomChange();
    }
}
