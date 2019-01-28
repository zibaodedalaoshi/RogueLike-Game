﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootInRange : MonoBehaviour {

 public float playerRange;

    public GameObject EnemyBiu;

    public PlayerController player;

    public Transform launchPoint;


    public float waitBetweenShots;
    private float shotCounter;


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        shotCounter = waitBetweenShots;


    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
        shotCounter -= Time.deltaTime;

        if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0)
        {
            
            Instantiate(EnemyBiu, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;
        }

        if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0)
        {
            
            Instantiate(EnemyBiu, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;

        }
    }
}
