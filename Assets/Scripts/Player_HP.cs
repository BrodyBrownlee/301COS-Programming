using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public static Player_HP playerHPScript;
    public GameObject hpPrefab;
    public float HP;
    public float MaxHP;
    public float hitDelay;
    public float invincibilityTime;
    // Start is called before the first frame update
    void Start()
    {
        playerHPScript = this;
    }
     void Awake()
    {
        updateHP();
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
            updateHP();
        }
        if (collision.gameObject.tag == "boss" && hitDelay >= invincibilityTime)
        {
            HP--;
            updateHP();
        }
    }
    private void updateHP()
    {
        var hearts = GameObject.FindGameObjectsWithTag("hp");
        foreach(var heart in hearts)
        {
            Destroy(heart);
        }
        for (int i = 0; i < HP; i++)
        {
            GameObject hpPlacerholder = Instantiate(hpPrefab);
            hpPlacerholder.transform.position = new Vector3(-130 + (15 * i), 0, 70);
        }
    }
}
