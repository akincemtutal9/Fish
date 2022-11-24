using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;

    private float timer;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 10)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0f;
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }
    
    
}