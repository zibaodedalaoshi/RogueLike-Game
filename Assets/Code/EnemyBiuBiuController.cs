using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBiuBiuController : MonoBehaviour {

    public float AttackSpeed;
    Rigidbody2D rigidbody2D;
    public PlayerController player;
    //public GameObject enemyDeathEffect;
    public GameObject impactEffect;
    //public float DestoryFlashDistance;

    public float rotationSpeed;

    public int damageToGive;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (player.transform.position.x < this.transform.position.x)
        {
            AttackSpeed = -AttackSpeed;
            rotationSpeed = -rotationSpeed;
        }
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(AttackSpeed, rigidbody2D.velocity.y);
        rigidbody2D.angularVelocity = rotationSpeed;
       // if (Mathf.Abs(rigidbody2D.transform.position.x - player.transform.position.x) >= DestoryFlashDistance)
       // {
            //Instantiate(impactEffect, transform.position, transform.rotation);
         //   Destroy(gameObject);
        //}
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            //Instantiate(enemyDeathEffect, collision.transform.position, collision.transform.rotation);
            //Destroy(collision.gameObject);
            HealthManager.HurtPlayer(damageToGive);

        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

    }


}
