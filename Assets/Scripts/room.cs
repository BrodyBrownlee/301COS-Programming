using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour
{
    public static room roomScript;
    public bool roomChanged;
    private void Awake()
    {
        roomScript = this;
    }
    public void roomChange()
    {
        roomChanged = true;
        Destroy(gameObject);
        return;
    }
}
