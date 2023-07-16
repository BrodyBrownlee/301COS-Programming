using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 32f;
    private Vector3 playerMovement;
    public float gravity = -9.81f;
    public float gravityMultiplier = 4f;
    private float yVelocity = 0;
    public float jumpingPower = 16f;
    CharacterController Cr;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        Cr = GetComponent<CharacterController>();
    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        bool grounded = GroundCheck();
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        playerMovement.x = xMove * speed * Time.deltaTime;
        playerMovement.z = zMove * speed * Time.deltaTime;

        if (grounded)
        {
            yVelocity = -0.5f;
        }
        else
        {
            yVelocity += gravity * Time.deltaTime * Time.deltaTime * gravityMultiplier;
        }
        playerMovement.y = yVelocity;
        Cr.Move(playerMovement);

        bool GroundCheck()
        {
            return Cr.isGrounded;
        }
    }
   
}
        
