﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public GameObject currentCheckpoint;

    private PlayerController player;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    public float respawnDelay;

    public HealthManager healthManager;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        healthManager = FindObjectOfType<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.isFacingRight = true;
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        healthManager.FullHealth();
        healthManager.isDead = false;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
