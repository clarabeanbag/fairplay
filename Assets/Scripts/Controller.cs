using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private PlayerActions playerActions;

    public GameObject housePrefab;

    private GameObject nextHouse;
    private Vector3 currentPosition;
    private float speed = 1f;

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
        playerActions.Main.Build.performed += _ => Build();
        nextHouse = Instantiate(housePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = Input.mousePosition;
        currentPosition.z = speed;
        nextHouse.transform.position = Camera.main.ScreenToWorldPoint(currentPosition);

    }

    private void Build()
    {
        GameObject builtHouse = Instantiate(housePrefab, nextHouse.transform);
        nextHouse = Instantiate(housePrefab);

    }
}
