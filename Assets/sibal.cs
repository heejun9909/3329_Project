using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sibal : MonoBehaviour
{
    // Radius of the overlap circle to determine if the player can stand up




    Rigidbody2D rigid;
    public float maxSpeed;
    public float jumpPower;
    SpriteRenderer spriterenderer;
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update(){
        //jump 
        if (Input.GetButtonUp("Jump") && !anim.GetBool("isJump")){
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);  
            anim.SetBool("isJump", true);
        }


        if (Input.GetButtonUp("Horizontal")){
            
            rigid.velocity  = new Vector2(rigid.velocity.normalized.x*0.5f, rigid.velocity.y);
        }

        if (Input.GetButtonDown("Horizontal"))
            spriterenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        
        if (rigid.velocity.normalized.x == 0)
            anim.SetBool("isRun", false);
        else
            anim.SetBool("isRun", true);


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);  
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity  = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed*(-1))
            rigid.velocity = new Vector2(maxSpeed*(-1),rigid.velocity.y);
        // Landing platform
        if (rigid.velocity.y < 0){
            Debug.DrawRay(rigid.position,Vector3.down, new Color(0,1,0));
            RaycastHit2D rayhit = Physics2D.Raycast(rigid.position,Vector3.down, 1.0f, LayerMask.GetMask("ground"));
            if (rayhit.collider != null){
                if (rayhit.distance< 0.4f){
                    anim.SetBool("isJump", false);
                }
            }
        }
    }

}

