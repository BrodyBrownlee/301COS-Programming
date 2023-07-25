using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject pfEnemy;
    public GameObject pfRoom;
    private GameObject enemyLoc;
    // Start is called before the first frame update
    void Start()
    {
        enemyLoc = GameObject.Find("enemySpawn");
        eSpawn();
        rSpawn();
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
    private void rSpawn()
    {
        GameObject newRoom = Instantiate(pfRoom);
        newRoom.transform.position = new Vector3(enemyLoc.transform.position.x,enemyLoc.transform.position.y - 1, enemyLoc.transform.position.z);
    }
}
