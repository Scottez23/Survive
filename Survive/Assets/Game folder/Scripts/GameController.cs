using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Starting variables for time and scale
    public float currentTime = 0.0f;
    public int diffucltyScale = 1;

   

    //If current time get to 15s, increment the difficulty scale and reset current time
    void Update()
    {
        if (currentTime > 15)
        {
            diffucltyScale += 1;
            currentTime = 0.0f;
        }

        currentTime += Time.deltaTime;
    }

    //Find out current 
    public float CurrentTime()
    {
        return currentTime;
    }

    //Find out current difficulty
    public int CurrentDiff()
    {
        return diffucltyScale;
    }
}


