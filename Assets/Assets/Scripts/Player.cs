using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rigid;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] private bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(horizontal,rigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rigid.velocity = new Vector2(rigid.velocity.x,jumpForce);

        }

    }
    


}
