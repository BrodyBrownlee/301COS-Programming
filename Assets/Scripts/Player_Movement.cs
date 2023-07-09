using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed = 32f;
    private Vector3 playerMovement;
    public float gravity = -9.81f;
    public float gravityMultiplier = 4f;
    private float yVelocity = 0;
    public float jumpingPower = 16f;
    public enum facingDirection
    {
        Up,
        Left,
        Right,
        Down
    }
    facingDirection facing;
    public int shootAngle = 0;
    CharacterController Cr;
    public LayerMask groundLayer;
  

       
    // Start is called before the first frame update
    void Start()
    {
        Cr = GetComponent<CharacterController>();
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

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            facing = facingDirection.Up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            facing = facingDirection.Down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            facing = facingDirection.Left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            facing = facingDirection.Right;
        }
    
        checkFacing(facing);
    }
    private void checkFacing(facingDirection facing)
    {
        if(facing == facingDirection.Left)
        {
            
        }
        else if (facing == facingDirection.Right)
        {

        }
        else if(facing == facingDirection.Up)
        {

        }
        else if(facing == facingDirection.Down)
        {

        }
        else
        {
            return up;
        }
    }
}
        
