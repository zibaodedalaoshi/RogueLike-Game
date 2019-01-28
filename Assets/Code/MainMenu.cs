using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string startLevel;

    public int playerLives;

	public void NewGame()
    {
        Application.LoadLevel(startLevel);

        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
	
}
