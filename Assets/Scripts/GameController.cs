using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
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
        
    }
    public void roomChange()
    {
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
        room.roomScript.roomChange();
        var enemySpawns = GameObject.FindGameObjectsWithTag("enemySpawn");
        foreach (var enemy in enemySpawns)
        {
            Destroy(enemy);
        }
    }
}