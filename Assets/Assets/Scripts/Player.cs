using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rigid;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool grounded = false;
    [SerializeField] private float values = .75f;
    [SerializeField]private int speed = 3;
    PlayerAnimation play;
    SpriteRenderer[] flipper;

    bool bugJump = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        play = GetComponent<PlayerAnimation>();
        flipper = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        attack();   
    }

    void move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(horizontal * speed,rigid.velocity.y);
        play.run(horizontal);
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            flipper[0].flipX = true;

            flipper[1].flipY = true;
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            flipper[0].flipX = false;
            flipper[1].flipY = false;
        }
       

    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() == true )
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            grounded = false;
            play.jump(true);
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Invoke("methods", 1f);
        }


    }

    void attack()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded() == true )
        {
            play.attack();
        }
    }

    void methods()
    {
        grounded = true;
        play.jump(false);

    }

    bool isGrounded()
    {


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, values, groundLayer.value);

        if (hit.collider != null)
        {
            grounded = true;
            return true;
        }
        return false;


    }

  

}
