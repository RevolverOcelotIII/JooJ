using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStuff : MonoBehaviour
{
    public Rigidbody2D charRB,swordRB;
    public float rotationspeed = 5;
    public bool trowed=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //swordRB.MovePosition(new Vector3(charRB.position.x + 1.5f, charRB.position.y + 1.5f));
        TrowSword();
        Aim();
    }
    void Aim()
    {
        Vector2 aimdirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(aimdirection.x, -aimdirection.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        if (trowed)
        {
            swordRB.gravityScale = 0;
            swordRB.transform.position = new Vector3(charRB.position.x + 1.2f, charRB.position.y + 1.2f);
            swordRB.transform.rotation = Quaternion.Slerp(swordRB.transform.rotation, rotation, rotationspeed * Time.deltaTime);
        }
    }
    void TrowSword()
    {
        if (Input.GetButtonDown("Attack2"))
        {
            swordRB.gravityScale = 1;
            Vector3 direcao = new Vector3(Mathf.Cos(swordRB.transform.rotation.z), Mathf.Sin(swordRB.transform.rotation.z));// swordRB.transform.rotation.z-90);
            //swordRB.velocity = Vector2.right * 10;
            //swordRB.velocity = direcao.normalized;
            swordRB.velocity=direcao.normalized * 10;
            trowed = false;
        }
    }
}
