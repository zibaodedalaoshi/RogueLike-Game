using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMain : MonoBehaviour {

    public float waitAfterGameOver;
    public string mainMenu;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        waitAfterGameOver -= Time.deltaTime;
        if(waitAfterGameOver<0)
        Application.LoadLevel(mainMenu);
    }
}
