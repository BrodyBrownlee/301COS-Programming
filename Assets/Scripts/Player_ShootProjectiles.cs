using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ShootProjectiles : MonoBehaviour
{
    public Transform pfBullet;

    // Start is called before the first frame update
    private void Awake()
    {
        GetComponent<Player_Aim>().OnShoot += Player_ShootProjectiles_OnShoot;
    }
    private void Player_ShootProjectiles_OnShoot(object sender, Player_Aim.OnShootEventArgs e)
    {
        Instantiate(pfBullet, e.gunEndPointPosition, pfBullet.rotation);
        pfBullet.transform.localScale = new Vector3(20, 20, 1);
        pfBullet.transform.localRotation = new Quaternion(-90, 0, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
