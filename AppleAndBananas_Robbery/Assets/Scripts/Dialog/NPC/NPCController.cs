using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ActiveAnimTrigger(string triggerType) {
        switch (triggerType)
        {
            case "Jump":
                anim.SetTrigger(triggerType);
                break;
            case "Dance":
                anim.SetTrigger(triggerType);
                break;
            case "Victory":
                anim.SetTrigger(triggerType);
                break;

            default:
                break;
        }
    }


}
