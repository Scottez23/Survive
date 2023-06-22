using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHead : MonoBehaviour
{
    float health = 80.0f;
    public GameObject body;
    Vector3 exploDir;
    float exploForce;


    // Start is called before the first frame update
    void Start()
    {
        transform.parent = body.transform;
        //GameController gameController = FindObjectOfType<GameController>();
        health *= FindObjectOfType<GameController>().CurrentDiff();
    }

    public void TakeDamage(float damageToTake, float explosionForce, Vector3 explosionDirection)
    {
        exploDir = explosionDirection;
       exploForce = explosionForce;
        if (health > 0)
        {
            health = health - damageToTake;
            transform.parent.gameObject.GetComponent<ZombieMelee>().TakeDamage(damageToTake);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            exploDir.x *= Random.Range(-1, 1);
            exploDir.y *= Random.Range(-1, 1);
            exploDir.z *= Random.Range(-1, 1);
            transform.parent = null;
            gameObject.GetComponent<Rigidbody>().AddForce(exploDir * exploForce, ForceMode.Impulse);
            Destroy(this.gameObject, 1.0f);
            health = 100;
        }    
    }
}
