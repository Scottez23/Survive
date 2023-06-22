using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //variables needed for script
    public float spawnDelayOriginal;
    float spawnDelayNew;
    float spawnMod;
    float cooldown;
    public GameObject zombie;

   
    //Find player position and update spawnDelay. Once cooldown reaches 0, pick a random spawn point and spawn a zombie if its far enough from the player
    void Update()
    {
        Vector3 playerPos = FindObjectOfType<PlayerController>().CurrentPos();
        SDUpdate();

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        //run twice in situation spawn point is too close and hope new rand number isnt too close
        else 
        {
            cooldown = spawnDelayNew;
            Vector3 spawnPoint = transform.GetChild(Random.Range(0, transform.childCount - 1)).transform.position;
            
            if (Vector3.Distance(spawnPoint, playerPos) >= 20)
            {
                GameObject enemy = Instantiate(zombie, spawnPoint, Quaternion.identity);
            }

            else
            {
                spawnPoint = transform.GetChild(Random.Range(0, transform.childCount - 1)).transform.position;
                if (Vector3.Distance(spawnPoint, playerPos) >= 20)
                {
                    GameObject enemy = Instantiate(zombie, spawnPoint, Quaternion.identity);
                }
            }
        }

    }

    //Update spawnDelay
    private void SDUpdate()
    {
        int diff;
        diff = FindObjectOfType<GameController>().CurrentDiff();
        spawnDelayNew = spawnDelayOriginal / diff;

    }
}
