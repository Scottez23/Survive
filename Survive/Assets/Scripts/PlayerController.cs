using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

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

    //reference to gun variables
    public GameObject gun;

    //reference to bullet variables
    public GameObject bulletPrefab;
    public float bulletSpeed = 1f;
    public Transform bulletSpawnPoint;

    private PenSampler ps;
    public GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = FindObjectOfType<PlayerController>().gameObject;
        ps = playerObj.GetComponent<PenSampler>();
    }

    public void TakeDamage(int damage) {
        }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //Play game over text
            //Display Round score "you have survived x rounds"
        }

       

            if (Input.GetKeyDown(fireKey))
            {
            //GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
            //bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.transform.forward * bulletSpeed, ForceMode.Impulse);
            ps.UpdatePen();
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
