using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public bool hasStarted = false;

    private bool animalPicked = false;
    private bool mutationPicked = false;

    public GameObject mainMenu;

    public List<string> animalNames;
    public List<Image> animalImages;
    public List<string> funnyQuips;

    private int lastAnimal;
    private int finalQuip;

    private int animalNumber;
    private int quipNumber;

    public Image shownImage;

    private string animalName;
    private string quipSnyder;

    public Text funnyJoinQuip;

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
        gameStarted = main.gameStart;

        //mutationPicked = 

        if (gameStarted && !hasStarted)
        {
            hasStarted = true;

            StartCoroutine(GameRound());
        }
    }

    public IEnumerator GameRound()
    {
        PickAnimal();
        yield return new WaitWhile(() => !animalPicked);

        yield return new WaitForSeconds(5);

        mutate.SpawnMutationCards();

        yield return new WaitWhile(() => !mutationPicked);
    }

    public void PickAnimal()
    {
        animalNumber = Random.Range(0, lastAnimal);

        shownImage = animalImages[animalNumber];
        animalName = animalNames[animalNumber];

        quipNumber = Random.Range(0, finalQuip);

        quipSnyder = funnyQuips[quipNumber];

        funnyJoinQuip.text = animalName + " " + quipSnyder;

        animalPicked = true;
    }
}
