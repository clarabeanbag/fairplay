using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;

public class Controller : MonoBehaviour
{
    private PlayerActions playerActions;

    public GameObject[] housePrefabs;

    private GameObject nextHouse;
    private Vector3 currentPosition;
    private float speed = 1f;

    private int currentHouseType = 0;

    public TextMeshProUGUI housesleftText;

    //Pause Menu
    private bool pauseMenuOpen = false;
    public GameObject pauseMenu;

    private bool instructionsMenuOpen = false;

    private int housesLeft = 20;

    public GameObject tooltipCanvas;

    public AudioSource bgmusic;
    public AudioSource cityambience;
    public AudioSource buildsound;

    public SpriteRenderer bgSr;
    public Sprite afterBg;

    public static bool gameOver = false;

    private void Awake()
    {
        playerActions = new PlayerActions();
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }


    void Start()
    {
        instructionsMenuOpen = true;
        tooltipCanvas.SetActive(false);
        housesLeft = 20;
        Cursor.lockState = CursorLockMode.Confined;
        playerActions.Main.Build.performed += _ => Build();
        playerActions.Main.PauseUnpause.performed += _ => PauseUnpause();
        currentHouseType = Random.Range(0, 4);
        nextHouse = Instantiate(housePrefabs[currentHouseType]);
    }

    void Update()
    {
        if ((!pauseMenuOpen) && !instructionsMenuOpen && housesLeft > 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            currentPosition = Input.mousePosition;
            currentPosition.z = speed;
            nextHouse.transform.position = Camera.main.ScreenToWorldPoint(currentPosition);
        }

    }

    private void Build()
    {

        if ((!pauseMenuOpen) && housesLeft > 0)
        {
            if (nextHouse.transform.GetChild(0).GetComponent<House>().IsBuildable())
            {
                GameObject builtHouse = Instantiate(nextHouse, nextHouse.transform.position, Quaternion.identity);
                builtHouse.transform.GetChild(0).GetComponent<House>().SetSpriteNum(nextHouse.transform.GetChild(0).GetComponent<House>().GetSpriteNum());
                Destroy(nextHouse);
                builtHouse.transform.GetChild(0).GetComponent<House>().HouseIsBuilt();
                buildsound.Play();

                housesLeft -= 1;
                housesleftText.text = housesLeft.ToString();
                if (housesLeft == 0)
                {
                    gameOver = true;
                    tooltipCanvas.SetActive(true);
                    bgmusic.Stop();
                    cityambience.Play();
                    bgSr.sprite = afterBg;
                }
                else
                {
                    currentHouseType = Random.Range(0, 4);
                    nextHouse = Instantiate(housePrefabs[currentHouseType]);
                }
            }
        }
    }

    private void PauseUnpause()
    {
        if (pauseMenuOpen)
        {
            pauseMenu.SetActive(false);
            pauseMenuOpen = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            pauseMenuOpen = true;
        }
    }

    public void closeInstructions()
    {
        instructionsMenuOpen = false;
    }
}
