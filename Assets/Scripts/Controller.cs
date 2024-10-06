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
        currentHouseType = Random.Range(0, 4);
        nextHouse = Instantiate(housePrefabs[currentHouseType]);
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        currentPosition = Input.mousePosition;
        currentPosition.z = speed;
        nextHouse.transform.position = Camera.main.ScreenToWorldPoint(currentPosition);

    }

    private void Build()
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
