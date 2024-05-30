using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractionObject
{
    protected override void Start()
    {
        base.Start();
        msg = baseMessage + "����";
    }

    public override void Interaction(Player player)
    {
        toggle = !toggle;

        msg = baseMessage + (toggle ? "�ݱ�" : "����");
        animator.SetBool(interaction, toggle);
    }
}
