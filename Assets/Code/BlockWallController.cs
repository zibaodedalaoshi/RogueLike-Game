using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWallController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(FindObjectOfType<EnemyHealthManager>())
        {
            return;
        }

        Destroy(gameObject);
		
	}
}
