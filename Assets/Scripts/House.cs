using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.DefaultInputActions;

public class House : MonoBehaviour
{
    public Sprite[] spritesBefore;
    public Sprite[] spritesAfter;

    public GameObject Circle;

    private bool built = false;
    private bool buildable = true;

    private int spriteNum = 0;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
    }

    private void OnEnable()
    {
        spriteNum = Random.Range(0, 4);
        sr.sprite = spritesBefore[spriteNum];
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

    public void SetSpriteNum(int sn)
    {
        spriteNum = sn;
        sr.sprite = spritesBefore[spriteNum];
    }

    public bool IsBuildable() { return buildable; }

    public int GetSpriteNum() { return spriteNum; }
}
