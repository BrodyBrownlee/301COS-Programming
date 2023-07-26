using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enemySpawn spawnerScript;
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
        canAttack = false;
        hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
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
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
            spawnerScript.numberOfEnemies--;
        }
    }
    private void FixedUpdate()
    {
        /*if(!canAttack)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(directionToTarget.x, gameObject.transform.position.y,directionToTarget.y) * moveSpeed;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }*/
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "projectile")
        {
            hp -= 1;
        }
    }
}