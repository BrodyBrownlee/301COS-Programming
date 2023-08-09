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
    private bool canAttack;
    public  GameObject target;
    public NavMeshAgent agent;
    private Vector2 directionToTarget;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //set it's rotation to 90 on the x axis and set it's y position to 5
        gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 5, gameObject.transform.position.z);
        //if hp is less than or equal to 0
        if (hp <= 0)
        {
            //destroy enemy; 
            Debug.Log("enemy dead");
            Destroy(gameObject);
            //subtract one from the number of enemies
            enemySpawn.spawnerScript.numberOfEnemies--;
            return;
        }
      
    }
    private void FixedUpdate()
    {
        //if the enemy does not have a target
        if (target != null)
        {
            //set the destination of the agent to the target position
            agent.SetDestination(target.transform.position);
        }

        /*if(!canAttack)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(directionToTarget.x, gameObject.transform.position.y,directionToTarget.y) * moveSpeed;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }*/
    }
    private void enemyDead()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if a projectile collides with the enemy
        if(collision.gameObject.tag == "projectile")
        {
            //remove one health
            hp -= 1;
        }
    }
}
/*Vector2 enemyPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
       Vector2 targetPosition = new Vector2(target.transform.position.x, target.transform.position.z);
       Vector2 distanceToTarget = targetPosition - enemyPosition;
       directionToTarget = distanceToTarget.normalized;
       float numDistanceToTarget = distanceToTarget.magnitude;
       if(numDistanceToTarget <= attackRange)
       {
           canAttack = true;
       }
       else
       {
           canAttack = false;
       }*/


/*agent.updateRotation = false;
agent.updateUpAxis = false;*/
