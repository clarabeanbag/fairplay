using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hey");
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("ho");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("lets go");
    }
}