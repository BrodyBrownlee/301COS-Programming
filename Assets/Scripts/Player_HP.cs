using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public static Player_HP playerHPScript;
    public float HP;
    public float hitDelay;
    public float invincibilityTime;
    // Start is called before the first frame update
    void Start()
    {
        playerHPScript = this;
    }

    // Update is called once per frame
    void Update()
    {
        hitDelay += Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && hitDelay >= invincibilityTime)
        {
            HP--;
        }
    }
}
