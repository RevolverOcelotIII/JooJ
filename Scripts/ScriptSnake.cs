using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSnake : MonoBehaviour
{
    public Rigidbody2D snakeRB;
    public SpriteRenderer snakeSprite;
    public float speedwalk = 5;
    public int direction = 1;
    public LayerMask border,sword;
    public float timming=0;
    public Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        snakeRB.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        snakeRB.velocity = new Vector2(speedwalk * direction, snakeRB.velocity.y);
        if(timming > 0) timming -= Time.deltaTime;
        if (snakeRB.IsTouchingLayers(border)&&timming<=0)
        {
            direction *= -1;
            snakeSprite.flipX = direction > 0;
            timming = 1;
        }
        if (snakeRB.IsTouchingLayers(sword)&&playerAnim.GetBool("Attacking")&&CharController.timeattack<=0.4f) snakeRB.MovePosition(new Vector2(18f,5f));
    }
    private void OnTriggerEnter()
    {
        Debug.Log("Tocou");
    }
}
