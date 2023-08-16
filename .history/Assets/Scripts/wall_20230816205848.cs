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
        if(room.roomScript != null)
        {
            
        }
        if(room.roomScript.roomChanged == true)
        {
           Debug.Log("walls destroyed");
           Destroy(gameObject);
           return;
        }
    }
    public void roomChange()
    {
       
    }
}
