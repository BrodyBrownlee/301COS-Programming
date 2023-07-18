using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ShootProjectiles : MonoBehaviour
{
    public Transform pfBullet;
    public float projectileSpeed = 10f;
    // Start is called before the first frame update
    private void Awake()
    {
        GetComponent<Player_Aim>().OnShoot += Player_ShootProjectiles_OnShoot;
    }
    private void Player_ShootProjectiles_OnShoot(object sender, Player_Aim.OnShootEventArgs e)
    {
        Transform bullet = Instantiate(pfBullet, e.gunEndPointPosition, Quaternion.identity);

        // Disable gravity for the projectile
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.useGravity = false;

        // Calculate and apply velocity based on the shoot direction (only X and Z dimensions)
        Vector3 shootDirectionXZ = new Vector3(e.shootDirection.x, 0f, e.shootDirection.z);
        bulletRigidbody.velocity = shootDirectionXZ * projectileSpeed;

        // Adjust the rotation to align with the shoot direction
        Vector3 lookDirection = Vector3.forward;
        if (shootDirectionXZ != Vector3.zero)
        {
            lookDirection = shootDirectionXZ;
        }
        bullet.rotation = Quaternion.Euler(90f, Mathf.Atan2(e.shootDirection.x, e.shootDirection.z) * Mathf.Rad2Deg, 0f);
    }
}
