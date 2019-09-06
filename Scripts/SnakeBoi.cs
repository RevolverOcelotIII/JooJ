using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBoi : MonoBehaviour
{
    public float speed, x;
    public bool isGrounded, isWall;
    public LayerMask ground;
    public Transform Floor,Wall;
    public SpriteRenderer snakeboi;
    public Rigidbody2D snakeRB;
    public bool istouchingground;
    public BoxCollider2D snakecollider;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*snakeRB.IsTouchingLayers(whatIsGround);
        isGrounded = Physics2D.OverlapCircle(Floor.position, 0.4f, whatIsGround);
        isWall = Physics2D.OverlapCircle(Wall.position, 0.2f, whatIsGround);*/
 //       if (IsGrounded(snakecollider))
 //       {
            /*x = transform.position.x;
            x += speed * Time.deltaTime;*/
            snakeRB.AddForce(new Vector2(speed, 0));
        //       }
    }
    bool IsGrounded(BoxCollider2D groundCollider)
    {
        RaycastHit2D Rcast = Physics2D.BoxCast(groundCollider.bounds.center, groundCollider.bounds.size, 0f, Vector2.down * 1, .1f, ground);
        return Rcast.collider != null;
    }
    private void OnTriggerEnter2D()
    {
        speed *= -1;
        snakeboi.flipX = speed < 0;
    }
}
