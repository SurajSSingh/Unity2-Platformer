using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePotion : Collectable
{
    private int scoreAdd;

    private void Start()
    {
        scoreAdd = 100;
    }

    override public void Use()
    {
        player.score += scoreAdd;
    }

    override public string Name()
    {
        return "Score Potion";
    }

}
