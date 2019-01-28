using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.GetComponent<AudioSource>().Stop();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.GetComponent<AudioSource>().Play();
        }

    }

}
