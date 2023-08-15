using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour
{
    public static room roomScript;
    public bool roomChanged;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        roomScript = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void roomChange()
    {
        Debug.Log("room destroyed");
        roomChanged = true;
        Destroy(gameObject);
        return;
    }
}
