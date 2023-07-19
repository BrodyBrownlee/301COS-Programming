using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    //creating game objects for the bullet prefab and projectile spawn for creating and centering the bullets
    public GameObject pfBullet;
    private GameObject projectileSpawn;

    private void Start()
    {
        projectileSpawn = gameObject.transform.Find("Projectileposition").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        //if a directional key is being pressed create a bullet and rotate based on the direction
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject newBullet = Instantiate(pfBullet);
            newBullet.transform.position = projectileSpawn.transform.position;
            newBullet.transform.Rotate(0, 0, getRotation());
        }
    }
    //finding the rotation based on the key press
    private float getRotation()
    { 
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return 180;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return 90;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return 270;
        }
        else
        {
            return 0;
        }
    }
}
