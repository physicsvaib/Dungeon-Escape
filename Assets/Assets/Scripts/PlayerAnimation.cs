using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator[] anim ;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    public void run(float move)
    {
        anim[0].SetFloat("Move", Mathf.Abs(move));
    }

    public void jump(bool jump)
    {
        anim[0].SetBool("Jump", jump);
    }

    public void attack()
    {
        anim[0].SetTrigger("Attack");
        anim[1].SetTrigger("attack");
    }

}
