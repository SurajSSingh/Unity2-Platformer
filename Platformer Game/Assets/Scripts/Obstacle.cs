using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Obstacle : MonoBehaviour
{
    abstract public void DoSomething(PlayerScript player);
}
