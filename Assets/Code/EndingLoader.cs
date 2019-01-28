using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingLoader : MonoBehaviour {

    private bool playerInZone;

    public string levelToLoad;

    // Use this for initialization
    void Start()
    {
        playerInZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone)
        {
            Application.LoadLevel(levelToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            playerInZone = false;
        }
    }
}
