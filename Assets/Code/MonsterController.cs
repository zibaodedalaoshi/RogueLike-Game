using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    public bool isFacingRight;
    public float maxSpeed = 1.5f;
    private Rigidbody2D m_rigidbody2D;
    Animator _anim;

    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 enemyScale = this.transform.localScale;
        enemyScale.x = enemyScale.x * -1;
        this.transform.localScale = enemyScale;
    }

    void FixedUpdate()
    {

        if (this.isFacingRight == true)
        {
            
            this.m_rigidbody2D.velocity = new Vector2(maxSpeed, this.m_rigidbody2D.velocity.y);
        }
        else
        {
            
            this.m_rigidbody2D.velocity = new Vector2(-maxSpeed, this.m_rigidbody2D.velocity.y);
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            Flip();
        }
    }
}
