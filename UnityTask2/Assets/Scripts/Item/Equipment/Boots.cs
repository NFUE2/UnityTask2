using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : Equipment
{
    EquipData equipData;

    private void Start()
    {
        equipData = data as EquipData;
    }

    public override void Interaction(Player player)
    {
        this.player = player;

        player.Equip(this);
        Destroy(gameObject);
    }

    public override void Equip()
    {
        for(int i = 0; i < equipData.attribute.Length; i++)
        {
            EquipType type = equipData.attribute[i].type;

            switch(type)
            {
                case EquipType.Jump:
                    player.data.jumpPower += equipData.attribute[i].value;
                    break;

                case EquipType.Speed:
                    player.data.speed += equipData.attribute[i].value;
                    break;
            }
        }
    }

    public override void UnEquip()
    {
        for (int i = 0; i < equipData.attribute.Length; i++)
        {
            EquipType type = equipData.attribute[i].type;

            switch (type)
            {
                case EquipType.Jump:
                    player.data.jumpPower -= equipData.attribute[i].value;
                    break;

                case EquipType.Speed:
                    player.data.speed -= equipData.attribute[i].value;
                    break;
            }
        }
    }
}
