using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWhenHover : MonoBehaviour
{
    public bool startRotate = false;
    public float rotationSpeed;

    private void OnMouseOver()
    {
        startRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(startRotate && gameObject.transform.eulerAngles.y < 270)
        {
            gameObject.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}
