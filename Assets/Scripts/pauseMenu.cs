using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour
{
   public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1 );//loads the menu
    }
    public void QuitGame()
    {
        //quits the application
        Application.Quit();
    }
}
