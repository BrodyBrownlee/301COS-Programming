using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public float hp = 3;
    public float moveSpeed;
    public float attackRange;
    public GameObject target;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        hp = 3;
    }
    // Update is called once per frame
    void Update()
    {
        agent.transform.rotation = Quaternion.Euler(90, 0, 0);
        agent.transform.position = new Vector3(agent.transform.position.x, 5, agent.transform.position.z);
        //if hp is less than or equal to 0
        if (hp <= 0)
        {
            //destroy enemy; 
            Debug.Log("enemy dead");
            Destroy(gameObject);
            if (enemySpawn.spawnerScript != null)
            {
                //subtract one from the number of enemies
                enemySpawn.spawnerScript.numberOfEnemies--;
                return;
            }
        }
    }
    private void FixedUpdate()
    {
        //if the enemy does not have a target
        if (target != null)
        {
            if(!agent.pathPending)
            {
                agent.SetDestination(target.transform.position);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if a projectile collides with the enemy
        if (collision.gameObject.tag == "projectile")
        {
            //remove one health
            hp -= 1;
        }
    }
}
