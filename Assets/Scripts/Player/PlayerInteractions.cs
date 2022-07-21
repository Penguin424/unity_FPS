using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PlayerInteractions: OnTriggerEnter");

        if (other.gameObject.CompareTag("GunAmmor"))
        {

            GameManager.Instance.gunAmmo += other.GetComponent<AmmoBox>().ammo;

            Destroy(other.gameObject);
        }
    }

}
