using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollisionDetect : MonoBehaviour
{

    int value;

    private int parentSpriteNum;

    public House parentHouse;
    // Start is called before the first frame update
    void Start()
    {
        parentHouse = transform.parent.GetChild(0).GetComponent<House>();
        parentSpriteNum = parentHouse.GetSpriteNum();
        Debug.Log(parentSpriteNum);
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
            parentHouse.CalculateFinalValue(true, CalculateAreaEffectValue(parentSpriteNum, value) );
         }
         Debug.Log("current house value: " + parentHouse.GetFinalValue());
    }

    void OnTriggerExit2D(Collider2D col)
    {
         if (col.gameObject.tag == "House")
         {
            value = col.gameObject.GetComponent<House>().GetSpriteNum();
            parentHouse.CalculateFinalValue(false, CalculateAreaEffectValue(parentSpriteNum, value) );
         }
         Debug.Log("current house value: " + parentHouse.GetFinalValue());
    }

    int CalculateAreaEffectValue(int a, int b){
        if((a < b) || (a > b))
            return a - b;
        else return a;
    }
}
