using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.RightBracket))
        {
            GameObject newEnemy = Instantiate(pfEnemy);
            newEnemy.transform.position = enemyLoc.transform.position;

        }
    }
    private void eSpawn()
    {
        Debug.Log("Spawned!");
        GameObject newEnemy = Instantiate(pfEnemy);
        newEnemy.transform.position = enemyLoc.transform.position;
    }
}
