using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticle : MonoBehaviour {

    private ParticleSystem thisparticleSystem;

	// Use this for initialization
	void Start () {
        thisparticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (thisparticleSystem.isPlaying)
            return;

        Destroy(gameObject);
	}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
