using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public float speed;
    public float flipDirection;

    private bool gameStarted = true;

    private Vector3 move2d;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        move2d = new Vector3(0, speed * Time.deltaTime, 0);
        StartCoroutine(TankFloat());
    }

    private void Update()
    {
        move2d = new Vector3(0, speed * Time.deltaTime, 0);
        rb2d.AddForce(move2d);
    }

    private IEnumerator TankFloat()
    {
        yield return new WaitForSeconds(flipDirection);
        speed *= 2;
        while (gameStarted)
        {
            speed *= -1;
            yield return new WaitForSeconds(flipDirection);
        }
    }
}
