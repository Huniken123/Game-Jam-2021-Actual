using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMutations : MonoBehaviour
{
    public GameObject Group2Spawn1;
    public GameObject Group2Spawn2;
    public GameObject Group3Spawn1;
    public GameObject Group3Spawn2;
    public GameObject Group3Spawn3;

    private int cardToSpawn1;
    private int cardToSpawn2;
    private int cardToSpawn3;

    public List<GameObject> mutationCards;
    public List<GameObject> rareMutationCards;

    private int lastMutationIndex;
    private int lastRareMutationIndex;

    public int rareSpawnThreshold;

    private float randomNumber;

    public void SpawnMutationCards()
    {
        Debug.Log("Made it to Method");

        lastMutationIndex = mutationCards.Count;
        lastRareMutationIndex = rareMutationCards.Count;

        randomNumber = Random.Range(0, 100);

        // Spawn 3 Cards With 1 Rare Card
        if(rareSpawnThreshold <= randomNumber)
        {
            Debug.Log("Spawning 3 cards!");

            cardToSpawn1 = Random.Range(0, lastMutationIndex);
            cardToSpawn2 = Random.Range(0, lastRareMutationIndex);
            cardToSpawn3 = Random.Range(0, lastMutationIndex);

            Instantiate(mutationCards[cardToSpawn1], Group3Spawn1.transform.position, Group3Spawn1.transform.rotation);
            Instantiate(rareMutationCards[cardToSpawn2], Group3Spawn2.transform.position, Group3Spawn2.transform.rotation);
            Instantiate(mutationCards[cardToSpawn3], Group3Spawn3.transform.position, Group3Spawn3.transform.rotation);
        }
        else //Spawn 2 Cards
        {
            Debug.Log("Spawning 2 Cards!");

            cardToSpawn1 = Random.Range(0, lastMutationIndex);
            cardToSpawn2 = Random.Range(0, lastMutationIndex);

            Instantiate(mutationCards[cardToSpawn1], Group2Spawn1.transform.position, Group2Spawn1.transform.rotation);
            Instantiate(mutationCards[cardToSpawn2], Group2Spawn2.transform.position, Group2Spawn2.transform.rotation);
        }
    }
}
