using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    //creating game objects for the bullet prefab and projectile spawn for creating and centering the bullets
    public GameObject pfBullet;
    private GameObject projectileSpawn;
    private GameObject enemyHeight;
    public float shootDelay = 1f;
    public float timer = 1f;
    private float rotation;
    private void Start()
    {
        projectileSpawn = gameObject.transform.Find("Projectileposition").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //if a directional key is being pressed create a bullet and rotate based on the direction
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (shootDelay < timer)
            {
                GameObject newBullet = Instantiate(pfBullet);
                if( = 180)
                {

                }
                newBullet.transform.position = projectileSpawn.transform.position;
                newBullet.transform.Rotate(0,0, getRotation());
                timer = 0;
            }
        }
    }
    //finding the rotation based on the key press
    private float getRotation(float rotation)
    { 
        if (Input.GetKey(KeyCode.DownArrow))
        {
            return 180; 
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return 90;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return 270;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            return 0;
        }
        else
        {
            return 0;
        }
    }
}
