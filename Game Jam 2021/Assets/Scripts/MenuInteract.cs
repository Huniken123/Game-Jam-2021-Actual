using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInteract : MonoBehaviour
{
    public GameObject mainMenu;

    public bool gameStart = false;

    public void StartGame()
    {
        gameStart = true;
        mainMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
