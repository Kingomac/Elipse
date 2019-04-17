using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAppBut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!Screen.fullScreen)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
