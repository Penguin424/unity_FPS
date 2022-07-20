using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;
    public float shotForce = 1500f;
    public float shotRate = 0.5f;
    public float shotRateTime = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shotRateTime)
            {
                shotRateTime = Time.time + shotRate;
                GameObject bulletClone = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                bulletClone.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
                shotRateTime = Time.time + shotRate;

                Destroy(bulletClone, 5f);
            }
        }
    }
}
