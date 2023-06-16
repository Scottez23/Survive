using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //Bullet variables
    public int penetration = 100;
    public int damage = 10;
    public float bulletDespawn = 0.7f;


    //Despawn so bullets arn't instanciating and cluttering the world space
    void Start()
    {
        Destroy(this.gameObject, bulletDespawn);
    }

    //On collision, detect what i hit, give damage, despawn
    private void OnCollisionEnter(Collision other)
   {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<ZombieMelee>().TakeDamage(damage);
        }
   
        Destroy(this.gameObject);
  }


}

    
