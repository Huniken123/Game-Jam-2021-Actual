using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public bool hasStarted = false;

    private bool animalPicked = false;
    public bool mutationPicked = false;
    public bool discard = false;
    private bool gameEnded = false;

    public GameObject mainMenu;

    public List<string> animalNames;
    public List<Image> animalImages;
    public List<string> funnyQuips;
    public List<GameObject> cards;

    private int lastAnimal;
    private int finalQuip;

    private int animalNumber;
    private int quipNumber;
    public int cardIndex;

    private string animalName;
    private string quipSnyder;

    public Text funnyJoinQuip;

    public float mutationPoints;

    public Text pointText;

    private float gamePoints;
    public float minimumPoints;
    public float maximumPoints;

    public GameObject goodEnding;
    public GameObject badEnding;

    private MenuInteract main;

    private SpawnMutations mutate;

    // Start is called before the first frame update
    void Start()
    {
        main = mainMenu.GetComponent<MenuInteract>();
        mutate = GetComponent<SpawnMutations>();

        lastAnimal = animalNames.Count;
        finalQuip = funnyQuips.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log(mutationPicked);
        pointText.gameObject.SetActive(true);
        StartCoroutine(GameRound());
    }

    public IEnumerator GameRound()
    {
        while (!gameEnded)
        {
            yield return new WaitForSeconds(3);

            PickAnimal();
            Debug.Log("Animal Picked!");

            yield return new WaitWhile(() => !animalPicked);

            yield return new WaitForSeconds(5);

            funnyJoinQuip.text = " ";

            mutate.SpawnMutationCards();

            yield return new WaitWhile(() => !mutationPicked);

            Debug.Log("Communication!");

            DiscardCards();

            yield return new WaitForSeconds(1);

            CheckForBadOrGood();

            yield return new WaitForSeconds(3);

            CheckForEndGame();

            ResetStats();
        }
    }

    public void PickAnimal()
    {
        animalNumber = Random.Range(0, lastAnimal);

        animalImages[animalNumber].gameObject.SetActive(true);
        animalName = animalNames[animalNumber];

        quipNumber = Random.Range(0, finalQuip);

        quipSnyder = funnyQuips[quipNumber];

        funnyJoinQuip.text = animalName + " " + quipSnyder;

        animalPicked = true;
    }

    public void DiscardCards()
    {
        discard = true;
    }

    public void CheckForBadOrGood()
    {
        Debug.Log(mutationPoints);
        Debug.Log(cardIndex);

        if(animalNumber == 0 && (cardIndex == 3 || cardIndex == 4 || cardIndex == 5 || cardIndex == 6 || cardIndex == 10 || cardIndex == 11 || cardIndex == 12 || cardIndex == 13 || cardIndex == 16))
        {
            gamePoints += mutationPoints;
            Debug.Log("Hi!");
        }
        else if (animalNumber == 0)
        {
            gamePoints -= mutationPoints;
            Debug.Log("Hi!");
        }

        if(animalNumber == 1 && (cardIndex == 6 || cardIndex == 10 || cardIndex == 12 || cardIndex == 16))
        {
            gamePoints += mutationPoints;
            Debug.Log("Hi!");
        }
        else if (animalNumber == 1)
        {
            gamePoints -= mutationPoints;
            Debug.Log("Hi!");
        }

        if(animalNumber == 2 && (cardIndex == 4 || cardIndex == 6 || cardIndex == 8 || cardIndex == 9 || cardIndex == 10 || cardIndex == 12 || cardIndex == 13 || cardIndex == 15 || cardIndex == 16))
        {
            gamePoints += mutationPoints;
            Debug.Log("Hi!");
        }
        else if (animalNumber == 2)
        {
            gamePoints -= mutationPoints;
            Debug.Log("Hi!");
        }

        if (animalNumber == 3 && (cardIndex == 3 || cardIndex == 6 || cardIndex == 10))
        {
            gamePoints += mutationPoints;
            Debug.Log("Hi!");
        }
        else if (animalNumber == 3)
        {
            gamePoints -= mutationPoints;
            Debug.Log("Hi!");
        }

        if (animalNumber == 4 && (cardIndex == 3 || cardIndex == 5 || cardIndex == 6 || cardIndex == 10 || cardIndex == 12 || cardIndex == 13 || cardIndex == 15))
        {
            gamePoints += mutationPoints;
            Debug.Log("Hi!");
        }
        else if (animalNumber == 4)
        {
            gamePoints -= mutationPoints;
            Debug.Log("Hi!");
        }

        if (animalNumber == 5 && (cardIndex == 1 || cardIndex == 5 || cardIndex == 7 || cardIndex == 9 || cardIndex == 10 || cardIndex == 13 || cardIndex == 16))
        {
            gamePoints += mutationPoints;
            Debug.Log("Hi!");
        }
        else if (animalNumber == 5)
        {
            gamePoints -= mutationPoints;
            Debug.Log("Hi!");
        }

        if (animalNumber == 6 && (cardIndex == 5 || cardIndex == 6 || cardIndex == 7 || cardIndex == 10 || cardIndex == 15 || cardIndex == 16))
        {
            gamePoints += mutationPoints;
            Debug.Log("Hi!");
        }
        else if (animalNumber == 6)
        {
            gamePoints -= mutationPoints;
            Debug.Log("Hi!");
        }

        Debug.Log(gamePoints);
        pointText.text = "Points: " + gamePoints;
    }

    public void CheckForEndGame()
    {
        if(gamePoints > maximumPoints)
        {
            //Good Ending!
            goodEnding.SetActive(true);
            gameEnded = true;
            Debug.Log("Good Ending!");
        }

        if(gamePoints < minimumPoints)
        {
            //Bad Ending!
            badEnding.SetActive(true);
            gameEnded = true;
            Debug.Log("Bad Ending!");
        }
    }

    public void ResetStats()
    {
        animalImages[animalNumber].gameObject.SetActive(false);

        gameStarted = false;
        hasStarted = false;
        animalNumber = 0;
        quipNumber = 0;
        animalPicked = false;
        mutationPoints = 0;
        mutationPicked = false;
        discard = false;
    }
}
