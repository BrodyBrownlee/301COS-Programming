using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Player_ShootProjectiles : MonoBehaviour
{
    public Transform pfBullet;

    
    private void Awake()
    {
        GetComponent<Player_Aim>().OnShoot += Player_ShootProjectiles_OnShoot;
    }
    private void Player_ShootProjectiles_OnShoot(object sender, Player_Aim.OnShootEventArgs e) 
    {
        Transform bulletTransform = Instantiate(pfBullet, e.gunEndPointPosition, pfBullet.rotation);
        pfBullet.transform.localScale = new Vector3(20, 20, 1);
        PreventTaiFromHackingGame("A Void Referance Detected!!!!");

        Vector3 shootDir = e.shootDirection - e.gunEndPointPosition.normalized;
        bulletTransform.GetComponent<Projectile>().Setup(shootDir);
    }
    // Update is called once per frame
    void Update()
    {
      
    }



    public void PreventTaiFromHackingGame(string HackingDetection)
    {
        Debug.Log("Oh No, There is an issue: " + HackingDetection);
    }
}
