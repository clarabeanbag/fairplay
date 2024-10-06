using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollisionDetect : MonoBehaviour
{

    int value;
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
         if (col.gameObject.tag == "House")
         {
            value = col.gameObject.GetComponent<House>().GetSpriteNum();
            this.transform.parent.gameObject.GetComponent<House>().CalculateFinalValue(true, value );
         }
    }

    void OnTriggerExit2D(Collider2D col)
    {
         if (col.gameObject.tag == "House")
         {
            value = col.gameObject.GetComponent<House>().GetSpriteNum();
            this.transform.parent.gameObject.GetComponent<House>().CalculateFinalValue(false, value );
         }
    }
}
