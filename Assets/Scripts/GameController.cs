using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    public bool gameEnd = false;
    bool roomTransistioning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        gameController = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_HP.playerHPScript != null)
        {
        if (Player_HP.playerHPScript.HP <= 0 && !gameEnd)
            {
                gameOver();
                gameEnd = true;
            }
        }
    }
    public void gameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);//loads the main menu
        Debug.Log("Game Over");
    }
    public void roomChange()
    {
        StartCoroutine(roomTransistion());
        var enemySpawns = GameObject.FindGameObjectsWithTag("enemySpawn");
        foreach (var enemy in enemySpawns)
        {
            Destroy(enemy);
        }
        Debug.Log("wall destroyed");
        var walls = GameObject.FindGameObjectsWithTag("blockingDoors");
        foreach (var wall in walls)
        {
            Destroy(wall);
        }
        var projectiles = GameObject.FindGameObjectsWithTag("projectile");
        foreach (var projectile in projectiles)
        {
            Destroy(projectile);
        }

        var triggers = GameObject.FindGameObjectsWithTag("trigger");
        foreach(var trigger in triggers )
        {
            Destroy(trigger);
        }
        roomSpawn.roomScript.drawMiniMap();
        roomSpawn.roomScript.triggerSpawned = false;
        room.roomScript.roomChange();
    }
    IEnumerator roomTransistion()
    {
        if(!roomTransistioning)
        {
            roomTransistioning = true;
            float timeElapsed = 0;
            float lerpDuration = 1f;
            float transparency;
            Color32 colour;
            GameObject image = GameObject.Find("Image");
            colour = new Color32(0, 0, 0, 255);
            image.GetComponent<Image>().color = colour;
            while (timeElapsed < lerpDuration)
            {
                transparency = Mathf.Lerp(255, 0, timeElapsed / lerpDuration);
                colour = new Color32(0, 0, 0, (byte)transparency);
                image.GetComponent<Image>().color = colour;
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            colour = new Color32(0, 0, 0, 0);
            image.GetComponent<Image>().color = colour;
            roomTransistioning = false;
            yield break;
        } 
    }
}
