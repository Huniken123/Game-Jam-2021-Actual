using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInteract : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameManager;

    private GameManager GM;

    public bool gameStart = false;

    public void Start()
    {
        GM = gameManager.GetComponent<GameManager>();
    }

    public void StartGame()
    {
        gameStart = true;

        Debug.Log("Game Started!");

        GM.StartGame();

        mainMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}
