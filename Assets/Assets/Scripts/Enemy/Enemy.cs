using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int spped;
    [SerializeField] protected int gems;

    [SerializeField] protected Transform PointA, PointB;
    Vector3 currentPos;
    Animator anim;
    SpriteRenderer sprite;
    [SerializeField] bool isIdle;

    public void initi()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        Update();
        isIdle = false;
    }

    private void Start()
    {
        initi();
    }

    void Move()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {


            if (currentPos == PointA.position)
            {
                sprite.flipX = false;
                Debug.Log("False " + this.gameObject.name);
            }
            else
            {
                sprite.flipX = true;
                Debug.Log("True " + this.gameObject.name);

            }
            if (transform.position == PointA.position)
            {
                currentPos = PointB.position;
                StartCoroutine("Inverter");

            }
            else if (transform.position == PointB.position)
            {
                currentPos = PointA.position;

                StartCoroutine("Inverter");

            }
            transform.position = Vector3.MoveTowards(transform.position, currentPos, spped * Time.deltaTime);

        }
        else
        {
            isIdle = !isIdle;
        }
    }
    IEnumerator Inverter()
    {

        isIdle = !isIdle;
        yield return new WaitForSeconds(3f);

    }

    void animate()
    {
        if (isIdle == true)
        {
            anim.SetBool("Idle", true);
        }
        else
        {
            anim.SetBool("Idle", false);
        }
    }

    public virtual void Update() {

        Move();
        animate();

    }


}
