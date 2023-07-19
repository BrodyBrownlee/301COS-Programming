using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public GameObject pfBullet;
    private GameObject projectileSpawn;

    private void Start()
    {
        projectileSpawn = gameObject.transform.Find("Projectileposition").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            /* Aim();
             Shoot();*/
            Debug.Log("Shoot Key Pressed");
            GameObject newBullet = Instantiate(pfBullet);
            newBullet.transform.position = projectileSpawn.transform.position;
            newBullet.transform.Rotate(0, 0, getRotation());
        }
    }
    private float getRotation()
    {
        Debug.Log("Finding Angle");
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return 180;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return 270;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return 90;
        }
        else
        {
            return 0;
        }
    }
}
