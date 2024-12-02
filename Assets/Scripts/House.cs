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

    private int baseValue = 10; 
    private int finalValue = 0;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        if (Controller.gameOver == true)
        {
            sr.sprite = spritesAfter[spriteNum];
        }
    }

    private void OnEnable()
    {
        spriteNum = Random.Range(0, 4);
        sr.sprite = spritesBefore[spriteNum];
        CalculateBaseValue();
        finalValue = baseValue;
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
            ScoreManager.instance.CalculateScore(finalValue);
        }
    }

    public void SetSpriteNum(int sn)
    {
        spriteNum = sn;
        sr.sprite = spritesBefore[spriteNum];
    }

    public bool IsBuildable() { return buildable; }

    public int GetSpriteNum() { return spriteNum; }

    public int GetFinalValue() { return finalValue; }

    private void CalculateBaseValue()
    {
        baseValue += (baseValue / 2) * spriteNum;
    }

    public void CalculateFinalValue(bool within,int bonus)
    {
        if(within)
            finalValue += bonus;
        else 
            finalValue -= bonus;
    }
}
