using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;

    public GameObject mainMenu;

    private MenuInteract main;

    // Start is called before the first frame update
    void Start()
    {
        main = mainMenu.GetComponent<MenuInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        gameStarted = main.gameStart;

        if (gameStarted)
        {
            Debug.Log("GO!");
        }
    }
}
