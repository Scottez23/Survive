using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject rayMarker;

    //action keys
    public KeyCode forwardsKey = KeyCode.W;
    public KeyCode backwardsKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode fireKey = KeyCode.Mouse0;


    //Movement variables
    public float forwardSpeed = 0.1f;
    public float backwardSpeed = 0.08f;
    public float strafeSpeed = 0.08f;
    public float sprintMod = 1.5f;

    //Player variables
    public float health = 100.0f;
    public float bulletDMG = 20.0f;
    public float exploForce = 2.0f;

    public float timeBetweenBullets = 0.2f;
    private bool canShoot = true;

    //reference to gun variables
    public GameObject gun;

    //reference to bullet variables
    public GameObject bulletPrefab;

    public Transform bulletSpawnPoint;


    public GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = FindObjectOfType<PlayerController>().gameObject;

    }

    private void ResetShooting()
    {
        canShoot = true;
    }

    public void TakeDamage(int damage)
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100.0f, Color.red);


        if (health <= 0)
        {
            //Play game over text
            //Display Round score "you have survived x rounds"
        }



        if (Input.GetKey(fireKey))
        {
            // GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
            float bulletPen = 100.0f;
            RaycastHit[] hits;
            hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward, 100.0f);

         


                if (canShoot == false)
                {
                    return;
                }

                canShoot = false;
                Invoke("ResetShooting", timeBetweenBullets);
            this.GetComponentInChildren<ParticleSystem>().Play();


                for (int i = 0; i < hits.Length; i++)
                {
                    if (bulletPen > 0)
                    {
                        rayMarker.transform.position = hits[i].point;

                        Debug.Log(hits[i].collider.transform.tag);
                        if (hits[i].collider.tag == "Head")
                        {
                            Vector3 exploDir;
                            exploDir = -(hits[i].transform.position - Camera.main.transform.position);

                            hits[i].collider.gameObject.GetComponent<ZombieHead>().TakeDamage(bulletDMG * 2, exploForce, exploDir);

                        }

                        if (hits[i].collider.tag == "LeftArm")
                        {
                            Vector3 exploDir;
                            exploDir = -(hits[i].transform.position - Camera.main.transform.position);

                            hits[i].collider.gameObject.GetComponent<ZombieLArm>().TakeDamage(bulletDMG, exploForce, exploDir);
                        }

                        if (hits[i].collider.tag == "RightArm")
                        {
                            Vector3 exploDir;
                            exploDir = -(hits[i].transform.position - Camera.main.transform.position);

                            hits[i].collider.gameObject.GetComponent<ZombieRArm>().TakeDamage(bulletDMG, exploForce, exploDir);
                        }

                        if (hits[i].collider.tag == "Enemy")
                        {
                            Vector3 exploDir;
                            exploDir = -(hits[i].transform.position - Camera.main.transform.position);

                            hits[i].collider.gameObject.GetComponent<ZombieMelee>().TakeDamage(bulletDMG);
                        }

                        bulletPen -= 20.0f;
                        rayMarker.GetComponentInChildren<ParticleSystem>().Play();
                    }
                }

            
        }

            if (Input.GetKey(forwardsKey))
            {
                transform.position = transform.position + (transform.forward * forwardSpeed);
            }

            if (Input.GetKey(backwardsKey))
            {
                transform.position = transform.position + (transform.forward * -backwardSpeed);
            }

            if (Input.GetKey(leftKey))
            {
                transform.position = transform.position + (transform.right * -strafeSpeed);
            }

            if (Input.GetKey(rightKey))
            {
                transform.position = transform.position + (transform.right * strafeSpeed);
            }

        }
    }
