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
    private void Update
    public void roomChange()
    {
        Debug.Log("walls destroyed");
        Destroy(gameObject);
        return;
    }
}
