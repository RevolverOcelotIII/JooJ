using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharActions : MonoBehaviour
{
    public CharacterController2D moveControl;
    public Animation attack;
    public CharacterController charcontrol;
    public SpriteRenderer charSprite;
    public Transform Floor,Attacking;
    public LayerMask WhatIsGround;
    public bool isTouchingGround, isGrounded;
    public Animator Anim;
    public Rigidbody2D MainCharRB;
    public int JumpForce = 200;
    public float RunForce = 0.5f;
    public float timeattack = 1;
    float horizontalmove = 0f;
    Vector2 moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        MainCharRB.freezeRotation = true;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            MainCharRB.AddForce(new Vector2(0,JumpForce));
            //MainCharRB.MovePosition(new Vector2(MainCharRB.position.x, 10 * Time.fixedDeltaTime));
        }
        //Input.GetAxis("Walking");
        isGrounded = Physics2D.OverlapCircle(Floor.position, 0.2f, WhatIsGround);

        isTouchingGround = MainCharRB.IsTouchingLayers(WhatIsGround);
        Anim.SetBool("Jumping", !isGrounded);
        /*
        if (Input.GetButton("Walking")) 
        {
            charSprite.flipX = false;
            MainCharRB.AddForce(new Vector2(5, 0));
            Anim.SetBool("Running", true);
        }
        if (Input.GetAxis("Walking") < 0)
        {
            charSprite.flipX = true;
            MainCharRB.AddForce(new Vector2(-5, 0));
            Anim.SetBool("Running", true);
        }
        else
        {
            Anim.SetBool("Running", false);
        }
        if (Input.GetButtonUp("Running")) MainCharRB.AddForce(new Vector2(-5, 0));
        Anim.SetBool("Falling", !isGrounded);
        horizontalmove = Input.GetAxisRaw("Walking") * runSpeed;*/
    }
    private void FixedUpdate()
    {

        //float moveHorizontal = Input.GetAxis("Walking");
        Vector2 horizontalmovement = new Vector2(Input.GetAxis("Walking"),0);
        moveSpeed = horizontalmovement.normalized * RunForce;
        if(Input.GetButton("Walking") && (isTouchingGround && isGrounded) &&!Input.GetButton("Jump")) MainCharRB.MovePosition(MainCharRB.position + moveSpeed * Time.fixedDeltaTime);
        if (Input.GetButton("Walking") && !isGrounded) MainCharRB.AddForce(new Vector2 (Input.GetAxisRaw("Walking")*30,0));
        if(Input.GetAxis("Walking") < 0) charSprite.flipX = true;
        if (Input.GetAxis("Walking") > 0) charSprite.flipX = false;
        if (Input.GetAxis("Walking") != 0) Anim.SetBool("Running", true);
        else Anim.SetBool("Running", false);

        if (Input.GetButtonDown("Attack") && !Input.GetButton("Walking")) Anim.SetBool("Attacking", true);
        if(Anim.GetBool("Attacking")) timeattack -= Time.deltaTime;
        if (timeattack <= 0)
        {
            Anim.SetBool("Attacking", false);
            timeattack = 1;
        }
        //else if(!Anim.isInitialized) Anim.SetBool("Attacking", false);

    }
    /*private void OnTriggerEnter2D()
    {
        MainCharRB.MovePosition(new Vector2(-16,1));
    }*/
}
