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

    //Find player and set up navAgent
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
      }

    //limbs or raycasts pass damage to zombie body (total health pool)
    public void TakeDamage(float damageToTake)
    {
        health = health - damageToTake;
    }

    //If zombie collides with player, pause the game (game end)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Break();
        }
    }

    //While health is above 0, walk at the Player. When health falls below 0, destroy zombie
    void Update()
    {
       
        if (health > 0)
        {
            navAgent.destination = player.transform.position;
        }

        if (health <= 0)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            Destroy(this.gameObject);


        }
    }
}
