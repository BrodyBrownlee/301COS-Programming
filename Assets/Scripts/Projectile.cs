using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed; // Speed of the bullet
    public float lifetime = 2f; // Time in seconds before the bullet is destroyed
    Rigidbody Rb; //rigidbody
    int rotation;//rotation of bullet
    Vector3 direction;//direction of force

    // Start is called before the first frame update
    void Start()
    {
        //creating a rigidbody for the projectiles in order to apply a force
        Rb = GetComponent<Rigidbody>();
        //finds rotation based on the rotation of the projectile object
        rotation = (int)this.transform.rotation.eulerAngles.y;
        //sets force based on the projectiles rotation
        if(rotation == 90) // facing right
        {
            direction = Vector3.right;
        }
        if(rotation == 180)//facing down
        {
            direction = Vector3.back;
        }
        if(rotation == 270)//facing left
        {
            direction = Vector3.left;
        }
        if(rotation == 0)//facing right
        {
            direction = Vector3.forward;
        }
        // Destroy the bullet after a specified lifetime
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
       /* gameObject.transform.position = new Vector3(gameObject.transform.position.x, 5,gameObject.transform.position.z);*/
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the bullet forward based on its rotation and speed
        Rb.velocity = direction * speed;
    }
    /// <summary>
    /// destroys bullet based on what it collides with using the tag
    /// </summary>
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Wall Hit");
         
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Hit");
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "door")
        {
            Debug.Log("Door Hit");
            Destroy(gameObject);
        }
    }
}
