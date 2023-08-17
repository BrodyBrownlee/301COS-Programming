using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public static wall wallScript;
    // Start is called before the first frame update
   
    private void Awake()
    {
        wallScript = this;
    }
    public void Update()
    {
      
    }
    public void roomChange()
    {
       Debug.Log("wall destroyed");
       var walls = GameObject.FindGameObjectsWithTag("blockingDoors");
        foreach(var wall in walls)
        {
            Destroy(wall);
        }
    }
}
