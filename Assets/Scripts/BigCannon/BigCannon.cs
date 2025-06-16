using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCannon : MonoBehaviour
{
    [SerializeField] private bool canShoot = true;

    [SerializeField] private Transform _cannonBallSpawnPoint;
    [SerializeField] private GameObject cannonBallPref;


    public void Shoot()
    {
        if (canShoot)
        {
            cannonBallPref.SetActive(true);
            canShoot = false;
        }
    }
}
