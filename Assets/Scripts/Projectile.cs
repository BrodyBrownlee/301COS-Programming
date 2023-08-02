using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed; // Speed of the bullet
    public float lifetime = 2f; // Time in seconds before the bullet is destroyed
    Rigidbody Rb;
    int rotation;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        rotation = (int)this.transform.rotation.eulerAngles.y;
        if(rotation == 90)
        {
            direction = Vector3.right;
        }
        if(rotation == 180)
        {
            direction = Vector3.back;
        }
        if(rotation == 270)
        {
            direction = Vector3.left;
        }
        if(rotation == 0)
        {
            direction = Vector3.forward;
        }
        // Destroy the bullet after a specified lifetime
        //Destroy(gameObject, lifetime);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Wall Hit");
            // Destroy the bullet when it collides with something
            // You can implement other behaviors here, e.g., dealing damage to enemies
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
