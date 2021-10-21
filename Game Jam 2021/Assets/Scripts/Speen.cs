using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speen : MonoBehaviour
{
    public float spin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, (spin * Time.deltaTime), 0);
    }
}
