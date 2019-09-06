using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    public Animator Anim;
    public Rigidbody2D charRB,swordRB;
    public BoxCollider2D colisor;
    public LayerMask ground,damage;
    public bool grounded = false,trowed=true;
    public float speedwalking = 10;
    public SpriteRenderer charset,aimsprite;
    public static float timeattack,timetofall=0.5f;
    public GameObject sword,aim;
    public Vector3 swordpositionplus;
    public Vector2 maxaim = new Vector2(10,10);
    // Start is called before the first frame update
    void Start()
    {
        charRB.freezeRotation = true;
        swordpositionplus = new Vector3(1.5f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (charRB.IsTouchingLayers(damage)) charRB.MovePosition(new Vector2(-16,1.5f));
        grounded = IsGrounded(colisor);
        if (!IsGrounded(colisor)) Anim.SetBool("Jumping",true);
        else Anim.SetBool("Jumping", false);
        /*if (Anim.GetBool("Jumping")) timetofall -= Time.deltaTime;
        if (timetofall <= 0)
        {
            Anim.SetBool("Jumping",false);
            Anim.SetBool("Falling", true);
            timetofall = 0.5f;
        }
        if(IsGrounded(colisor)) Anim.SetBool("Falling", false);*/
        if (Input.GetButtonDown("Jump")&&IsGrounded(colisor))
        {
            Anim.SetBool("Jumping", true);
            float jumpSpeed = 20f;
            charRB.velocity = Vector2.up * jumpSpeed;
        }
        Move(speedwalking,charset);
        if (Input.GetButtonDown("Attack") && !Input.GetButton("Walking")) Anim.SetBool("Attacking", true);
        if (Anim.GetBool("Attacking")) timeattack -= Time.deltaTime;
        if (timeattack <= 0)
        {
            Anim.SetBool("Attacking", false);
            timeattack = 0.7f;
        }
    }

    bool IsGrounded(BoxCollider2D groundCollider)
    {
        RaycastHit2D Rcast = Physics2D.BoxCast(groundCollider.bounds.center, groundCollider.bounds.size, 0f, Vector2.down * 1,.1f,ground);
        return Rcast.collider != null;
    }

    void Move(float speed,SpriteRenderer spriter)
    {
        if (Input.GetButton("Walking"))
        {
            charRB.velocity = new Vector2(speed * Input.GetAxisRaw("Walking"), charRB.velocity.y);
            Anim.SetBool("Running", true);
        }
        else
        {
            charRB.velocity = new Vector2(0, charRB.velocity.y);
            Anim.SetBool("Running", false);
        }
        if (Input.GetAxisRaw("Walking") < 0) spriter.flipX = true;
        if (Input.GetAxisRaw("Walking") > 0) spriter.flipX = false;
    }
}
