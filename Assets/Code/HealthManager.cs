using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public static int playerHealth;
    public int MaxPlayerHealth;

    Text text;

    private LevelManager levelManager;

    public bool isDead;

    private LifeManager lifeSystem;


    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();

        playerHealth = MaxPlayerHealth;

        levelManager = FindObjectOfType<LevelManager>();
        isDead = false;

        lifeSystem = FindObjectOfType<LifeManager>();
    }

    // Update is called once per frame
    void Update() {
        if (playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;
            levelManager.RespawnPlayer();
            lifeSystem.TakeLife();
            isDead = true;
        }
        text.text = "" + playerHealth;

    }

    public static void HurtPlayer(int damageToGive)
        {
        playerHealth -= damageToGive;
        }

    public void FullHealth()
    {
        playerHealth = MaxPlayerHealth;
    }

}
