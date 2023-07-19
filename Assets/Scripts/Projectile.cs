using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 30f; // Speed of the bullet
    public float lifetime = 2f; // Time in seconds before the bullet is destroyed

    // Start is called before the first frame update
    void Start()
    {
        // Destroy the bullet after a specified lifetime
        Destroy(gameObject, lifetime);
    }


    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward based on its rotation and speed
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Wall Hit");
        if (collision.gameObject.tag == "Wall")
        {
            // Destroy the bullet when it collides with something
            // You can implement other behaviors here, e.g., dealing damage to enemies
            Destroy(gameObject);
        }
    }
}
