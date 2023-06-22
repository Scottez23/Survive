using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public float currentTime = 0.0f;
    public int diffucltyScale = 1;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 15)
        {
            diffucltyScale += 1;
            currentTime = 0.0f;
        }

        currentTime += Time.deltaTime;
    }

    public float CurrentTime()
    {
        return currentTime;
    }

    public int CurrentDiff()
    {
        return diffucltyScale;
    }
}


