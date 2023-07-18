using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Aim : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootDirection;
    }
    private Transform aimProjectileEndPointTransform;
    public enum facingDirection
    {
        Up,
        Left,
        Right,
        Down
    }
    public facingDirection facing;
    public int shootAngle = 0;
    private void Awake()
    {
        aimProjectileEndPointTransform = transform.Find("Projectileposition");
    }
    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
    }
    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                gunEndPointPosition = aimProjectileEndPointTransform.position,
                shootDirection = GetShootDirection(),
            });
        }
    }
    private Vector3 GetShootDirection()
    {
        float angleInRadians = shootAngle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0f);
    }
    private void Aim()
    {
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
        if (facing == facingDirection.Left)
        {
            shootAngle = 270;
        }
        else if (facing == facingDirection.Right)
        {
            shootAngle = 90;
        }
        else if (facing == facingDirection.Up)
        {
            shootAngle = 0;
        }
        else if (facing == facingDirection.Down)
        {
            shootAngle = 180;
        }
        else
        {
            shootAngle = 0;
        }
    }
}
