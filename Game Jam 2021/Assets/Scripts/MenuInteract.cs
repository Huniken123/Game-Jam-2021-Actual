using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInteract : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameManager;

    private SpawnMutations mutate;

    public bool gameStart = false;

    public void StartGame()
    {
        gameStart = true;
        Debug.Log("Game Started!");

        mutate = gameManager.GetComponent<SpawnMutations>();

        mutate.SpawnMutationCards();
        mainMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
