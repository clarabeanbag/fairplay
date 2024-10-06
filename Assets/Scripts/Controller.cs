using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private PlayerActions playerActions;

    public GameObject[] housePrefabs;

    private GameObject nextHouse;
    private Vector3 currentPosition;
    private float speed = 1f;

    private int currentHouseType = 0;

    //Pause Menu
    private bool pauseMenuOpen = false;
    public GameObject pauseMenu;

    private bool instructionsMenuOpen = false;

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
        Cursor.lockState = CursorLockMode.Confined;
        playerActions.Main.Build.performed += _ => Build();
        playerActions.Main.PauseUnpause.performed += _ => PauseUnpause();
        currentHouseType = Random.Range(0, 4);
        nextHouse = Instantiate(housePrefabs[currentHouseType]);
    }

    void Update()
    {
        if ((!pauseMenuOpen))
        {
            Cursor.lockState = CursorLockMode.Confined;
            currentPosition = Input.mousePosition;
            currentPosition.z = speed;
            nextHouse.transform.position = Camera.main.ScreenToWorldPoint(currentPosition);
        }

    }

    private void Build()
    {

        if ((!pauseMenuOpen))
        {
            if (nextHouse.transform.GetChild(0).GetComponent<House>().IsBuildable())
            {
                GameObject builtHouse = Instantiate(nextHouse, nextHouse.transform.position, Quaternion.identity);
                builtHouse.transform.GetChild(0).GetComponent<House>().SetSpriteNum(nextHouse.transform.GetChild(0).GetComponent<House>().GetSpriteNum());
                Destroy(nextHouse);
                builtHouse.transform.GetChild(0).GetComponent<House>().HouseIsBuilt();
                currentHouseType = Random.Range(0, 4);
                nextHouse = Instantiate(housePrefabs[currentHouseType]);
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
}
