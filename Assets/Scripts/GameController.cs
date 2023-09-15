using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class GameController : MonoBehaviour
{
    //reference for other scripts
    public static GameController gameController;

    public bool gameEnd = false;
    public float bossNum;

    //checks if the room has already started the transition animation
    bool roomTransistioning = false;

    void Awake()
    {
        gameController = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_HP.playerHPScript != null)
        {
            //if the player has no health and the game hasn't already ended
        if (Player_HP.playerHPScript.HP <= 0 && !gameEnd)
            {
                gameOver();
                gameEnd = true;
            }
        }
        //if all the bosses have been defeated 
        if (bossNum == 0)
        {
            gameWin();
        }
    }
    //game over method 
    public void gameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);//loads the main menu
        Debug.Log("Game Over");
    }
    //game win method 
    public void gameWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);//loads the main menu
        Debug.Log("Game Win");
    }
    //changing room method 
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
    //roomTransition logic using Math.Lerp and changing the transparency of a black object which adds a fade in fade out effect 
    IEnumerator roomTransistion()
    {
        if(!roomTransistioning)
        {
            roomTransistioning = true;
            float timeElapsed = 0;
            //animation duration
            float lerpDuration = 1f;
            float transparency;
            Color32 colour;
            GameObject image = GameObject.Find("Image");
            colour = new Color32(0, 0, 0, 255);
            image.GetComponent<Image>().color = colour;
            while (timeElapsed < lerpDuration)
            {
                //makes the transparency of the object based on how far into the total animation time the game is
                transparency = Mathf.Lerp(255, 0, timeElapsed / lerpDuration);
                colour = new Color32(0, 0, 0, (byte)transparency);
                image.GetComponent<Image>().color = colour;
                timeElapsed += Time.deltaTime;
                //returns once the animation is complete
                yield return null;
            }
            //if the transistion is already happening don't do anything 
            colour = new Color32(0, 0, 0, 0);
            image.GetComponent<Image>().color = colour;
            roomTransistioning = false;
            yield break;
        } 
    }
}
