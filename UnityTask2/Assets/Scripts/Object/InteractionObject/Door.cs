using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractionObject
{
    protected override void Start()
    {
        base.Start();
        msg = baseMessage + "열기";
    }

    public override void Interaction(Player player)
    {
        toggle = !toggle;

        msg = baseMessage + (toggle ? "닫기" : "열기");
        animator.SetBool(interaction, toggle);
    }
}
