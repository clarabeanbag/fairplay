using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject Circle;

    private bool built = false;
    private bool buildable = true;

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
        if(col.gameObject.tag == "House")
        {
            Circle.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.2f);
            buildable = false;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "House")
        {
            Circle.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.2f);
            buildable = false;
        }       
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "House")
        {
            Circle.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 0.2f);
            buildable = true;
        }
    }

    public void HouseIsBuilt()
    {
        if (!built)
        {
            built = true;
            Circle.SetActive(false);
        }
    }

    public bool IsBuildable() { return buildable; }
}