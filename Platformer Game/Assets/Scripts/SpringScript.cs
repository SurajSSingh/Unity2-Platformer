using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : Obstacle
{
    private float bouncePower;
    private void Start()
    {
        bouncePower = 40.0f;   
    }
    override public void DoSomething(PlayerScript player)
    {
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f,bouncePower));
    }
}
