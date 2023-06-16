using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMelee : MonoBehaviour
{
    //Nav variables
    public GameObject player;
    private NavMeshAgent navAgent;

    //Zombie variables
    public float health = 100.0f;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int damageToTake)
    {
        health = health - damageToTake;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            navAgent.destination = player.transform.position;
        }

        if (health <= 0)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;

        }
    }
}
