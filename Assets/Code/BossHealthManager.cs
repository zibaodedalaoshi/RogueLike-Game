﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour {

    public int enemyHealth;

    public GameObject deathEffect;

    public string nextLevel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (enemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Application.LoadLevel(nextLevel);

        }

    }

    public void giveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
    }
}

