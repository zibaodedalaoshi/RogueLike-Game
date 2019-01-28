using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootController : MonoBehaviour {

    private float AttackSpeed;
    Rigidbody2D rigidbody2D;
    public PlayerController player;
    public GameObject impactEffect;

    public float rotationSpeed;

    public int damageToGive;
    // Use this for initialization
    void Start () {
        AttackSpeed = Random.Range(5, 25);
        player = FindObjectOfType<PlayerController>();
        if (player.transform.position.x < this.transform.position.x)
        {
            AttackSpeed = -AttackSpeed;
            rotationSpeed = -rotationSpeed;
        }
        rigidbody2D = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        rigidbody2D.velocity = new Vector2(AttackSpeed, rigidbody2D.velocity.y);
        rigidbody2D.angularVelocity = rotationSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            HealthManager.HurtPlayer(damageToGive);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
