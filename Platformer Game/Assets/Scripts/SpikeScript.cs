using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : Obstacle
{
    private float knockBack;
    private void Start()
    {
        knockBack = 25.0f;   
    }
    override public void DoSomething(PlayerScript player)
    {
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f,knockBack));
        player.health -= 10;
    }
}
