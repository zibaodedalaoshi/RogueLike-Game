using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Animator _anim;
    public float MoveSpeed = 30f;
    public float JumpPower = 1000f;
    public float x_min, x_max, y_min, y_max;
    private Rigidbody2D m_Rigidbody2D;
    Vector3 Start_Scale;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJumped;

    public Transform attackPoint;
    public GameObject BladeFlash;

    public bool isFacingRight = true;


    // Use this for initialization
    void Start () {
        _anim = GetComponent<Animator>();
        Start_Scale = transform.localScale;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
    
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);//检测角色是否在“地面上”
    }

    public void Jump()//跳跃函数
    {
        _anim.SetTrigger("Jump");
        //m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, JumpPower);
        m_Rigidbody2D.AddForce(new Vector2(0, JumpPower));
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            _anim.SetBool("Move", true);
            float xx = Input.GetAxisRaw("Horizontal");
            if(Input.GetKey(KeyCode.RightArrow))
            {
                isFacingRight = true;
                transform.localScale = new Vector3(Start_Scale.x, Start_Scale.y, Start_Scale.z);
                transform.Translate(Vector3.right * xx * MoveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                isFacingRight = false;
                transform.localScale = new Vector3(-Start_Scale.x, Start_Scale.y, Start_Scale.z);
                transform.Translate(-Vector3.left * xx * MoveSpeed * Time.deltaTime);
            }
        }
        else
        {
            _anim.SetBool("Move", false);
        }

        if(grounded)
        {
            doubleJumped = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _anim.SetTrigger("Attack");
            Instantiate(BladeFlash, attackPoint.position, attackPoint.rotation);
        }

        m_Rigidbody2D.position = new Vector2
        (
            Mathf.Clamp(m_Rigidbody2D.position.x, x_min, x_max),
            Mathf.Clamp(m_Rigidbody2D.position.y, y_min, y_max)
        );
	}
}
