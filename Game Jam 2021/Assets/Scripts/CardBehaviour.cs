using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    private GameObject gameManager;
    private Rigidbody rb;

    private GameManager GM;

    public int cardID;
    public float mutationValue;
    public float waitForDespawn;

    private bool picked = false;
    private bool startDiscard = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");

        GM = gameManager.GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        startDiscard = GM.discard;

        if (startDiscard)
        {
            if (picked)
            {
                GM.cardIndex = cardID;
                GM.mutationPoints = mutationValue;
                startDiscard = false;
                StartCoroutine(Despawn());
            }
            else
            {
                rb.useGravity = true;
                StartCoroutine(Despawn());
            }
        }
    }

    private void OnMouseDown()
    {
        picked = true;

        Debug.Log("Picked A Card!");

        Debug.Log(GM.mutationPicked);

        GM.mutationPicked = true;

        Debug.Log(GM.mutationPicked);
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(waitForDespawn);
        Destroy(this.gameObject);
    }
}
