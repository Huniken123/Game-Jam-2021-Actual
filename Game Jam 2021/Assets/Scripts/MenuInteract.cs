using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInteract : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameManager;

    public bool gameStart = false;

    public void StartGame()
    {
        gameStart = true;

        Debug.Log("Game Started!");

        mainMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
