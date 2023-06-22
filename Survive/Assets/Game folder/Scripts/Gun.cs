using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun: MonoBehaviour
{
    //Mouse button
    public KeyCode fireKey = KeyCode.Mouse0;
    //variables for script
    public float bulletDMG = 20.0f;
    public float exploForce = 2.0f;
    public float timeBetweenBullets = 0.2f;
    bool canShoot = true;
    //marker for hit points
    public GameObject rayMarker;

    //allows gun to shoot again
    private void ResetShooting()
    {
        canShoot = true;
    }


    //If firekey is pressed, fire a raycast that records all hits. Go through each hit and pass relevant information until penetration is 0
    void Update()
    {
        

        if (Input.GetKey(fireKey))
        {
            float bulletPen = 100.0f;
            RaycastHit[] hits;
            hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward, 100.0f);

            //Automatic fire code
            if (canShoot == false)
            {
                return;
            }

            canShoot = false;
            Invoke("ResetShooting", timeBetweenBullets);
            this.GetComponentInChildren<ParticleSystem>().Play();

            //For every hit, run this
            for (int i = 0; i < hits.Length; i++)
            {
                if (bulletPen > 0)
                {
                    rayMarker.transform.position = hits[i].point;

                    //If raycast hit head
                    Debug.Log(hits[i].collider.transform.tag);
                    if (hits[i].collider.tag == "Head")
                    {
                        Vector3 exploDir;
                        exploDir = -(hits[i].transform.position - Camera.main.transform.position);
                        hits[i].collider.gameObject.GetComponent<ZombieHead>().TakeDamage(bulletDMG * 2, exploForce, exploDir);
                        //blood splash for following body parts
                        rayMarker.GetComponentInChildren<ParticleSystem>().Play();
                    }

                    //If raycast hit left arm
                    if (hits[i].collider.tag == "LeftArm")
                    {
                        Vector3 exploDir;
                        exploDir = -(hits[i].transform.position - Camera.main.transform.position);
                        hits[i].collider.gameObject.GetComponent<ZombieLArm>().TakeDamage(bulletDMG, exploForce, exploDir);
                        rayMarker.GetComponentInChildren<ParticleSystem>().Play();
                    }

                    //If raycast hit right arm
                    if (hits[i].collider.tag == "RightArm")
                    {
                        Vector3 exploDir;
                        exploDir = -(hits[i].transform.position - Camera.main.transform.position);
                        hits[i].collider.gameObject.GetComponent<ZombieRArm>().TakeDamage(bulletDMG, exploForce, exploDir);
                        rayMarker.GetComponentInChildren<ParticleSystem>().Play();
                    }

                    //If raycast hit enemy body
                    if (hits[i].collider.tag == "Enemy")
                    {
                        Vector3 exploDir;
                        exploDir = -(hits[i].transform.position - Camera.main.transform.position);
                        hits[i].collider.gameObject.GetComponent<ZombieMelee>().TakeDamage(bulletDMG);
                        rayMarker.GetComponentInChildren<ParticleSystem>().Play();
                    }

                    //bullet pen goes down as rayCast hits things
                    bulletPen -= 20.0f;

                }
            }


        }
    }
}
