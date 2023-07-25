using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;

public class Enemy : MonoBehaviour
{
    public float hp = 3;
    public  Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = ("Player");
        hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "projectile")
        {
            hp -= 1;
        }
    }
}