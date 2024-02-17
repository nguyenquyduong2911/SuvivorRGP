using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
     Animator anim;
     PlayerMovement pm;
    SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pm.moveDir.x != 0 || pm.moveDir.y != 0)
        {
            anim.SetBool("Moving", true);        
            SpriteDirectionChecker();
        }
        else
        {
            anim.SetBool("Moving", false);
            SpriteDirectionChecker();
        }
    }

    void SpriteDirectionChecker()
    {
        if(pm.moveDir.x < 0)
        {
            sr.flipX = true;
        }
        else if(pm.moveDir.x > 0)
        {
            sr.flipX = false;
        }
    }
}
