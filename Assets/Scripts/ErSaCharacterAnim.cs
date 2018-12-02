using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErSaCharacterAnim : MonoBehaviour
{

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("ErSaisRunning", true);
        }
        else
        {
            anim.SetBool("ErSaisRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("ErSajump");
        }
    }
}