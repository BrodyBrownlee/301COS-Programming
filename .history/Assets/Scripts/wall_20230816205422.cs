using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public static wall wallScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        wallScript = this;
    }
    public void roomChange()
    {
        Debug.log("walls destroyed")
        Destroy(gameObject);
        return;
    }
}
