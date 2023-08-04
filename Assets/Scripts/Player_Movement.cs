using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 32f;
    private Vector3 playerMovement;
    CharacterController Cr;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        Cr = GetComponent<CharacterController>();
    }
    private void Update()
    {
     Cr.transform.position = new Vector3(Cr.transform.position.x,5, Cr.transform.position.z);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        playerMovement.x = xMove * speed * Time.deltaTime;
        playerMovement.z = zMove * speed * Time.deltaTime;
        Cr.Move(playerMovement);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "leftTrigger")
        {
            Debug.Log("Left Trigger");
            Cr.enabled = false;
            Cr.transform.position = new Vector3(60, 5, Cr.transform.position.z);
            Cr.enabled = true;
        }
        else if (other.name == "rightTrigger")
        {
            Debug.Log("right Trigger");
            Cr.enabled = false;
            Cr.transform.position = new Vector3(-69, 5, Cr.transform.position.z);
            Cr.enabled = true;
        }
        else if (other.name == "topTrigger")
        {
            Debug.Log("top Trigger");
            Cr.enabled = false;
            Cr.transform.position = new Vector3(Cr.transform.position.x, 5, -20);
            Cr.enabled = true;
        }
        else if (other.name == "bottomTrigger")
        {
            Debug.Log("bottom Trigger");
            Cr.enabled = false;
            Cr.transform.position = new Vector3(Cr.transform.position.x, 5, 98);
            Cr.enabled = true;
        }

    }
   
}
        
