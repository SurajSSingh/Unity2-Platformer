using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    protected PlayerScript player;

    public void addPlayer(PlayerScript p)
    {
        player = p;
    }
    public abstract string Name();

    public abstract void Use();
}
