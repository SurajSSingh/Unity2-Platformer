using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Collectable
{
    private float healthAdd;

    private void Start()
    {
        healthAdd = 10.0f;
    }

    override public void Use()
    {
        player.health += healthAdd;
    }

    override public string Name()
    {
        return "Health Potion";
    }
}
