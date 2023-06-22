using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLArm : MonoBehaviour
{
    //Variables needed for script
    float health = 20.0f;
    public GameObject body;
    Vector3 exploDir;
    float exploForce;

    //Set parent to avoid null reference later on
    void Start()
    {
        transform.parent = body.transform;
       

    }

    //Get information from raycastHit and apply damage to body parts health aswell as total health pool
    public void TakeDamage(float damageToTake, float explosionForce, Vector3 explosionDirection)
    {
        exploDir = explosionDirection;
        exploForce = explosionForce;
        if (health > 0)
        {
            //body part damage
            health = health - damageToTake;
            //total health pool damage
            transform.parent.gameObject.GetComponent<ZombieMelee>().TakeDamage(damageToTake);
        }
    }

    //If health becomes below 0, unfreeze contstraints on body part, decouple child body part, add a force to make it explode, destory limb after 1s
    void Update()
    {
        if (health <= 0)
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            exploDir.x *= Random.Range(-1, 1);
            exploDir.y *= Random.Range(-1, 1);
            exploDir.z *= Random.Range(-1, 1);
            transform.parent = null;
            gameObject.GetComponent<Rigidbody>().AddForce(exploDir * exploForce, ForceMode.Impulse);
            Destroy(this.gameObject, 1.0f);
            //In here so a force isnt added every frame whilst the limb has "exploded" off
            health = 100;
        }
    }
}
