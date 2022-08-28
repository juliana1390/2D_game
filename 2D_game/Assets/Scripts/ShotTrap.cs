using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTrap : MonoBehaviour
{
    public GameObject shot;
    private float shotTime;

    private void FixedUpdate()
    {
        shotTime = shotTime + Time.deltaTime;
        if (shotTime > 2)
        {
            Instantiate(shot, transform.position, Quaternion.Euler(0, 0, 90));
            shotTime = 0;
        }
    }
}
