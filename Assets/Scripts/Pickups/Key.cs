using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Pickup
{
    [SerializeField]
    KeyColor keyColor;

    public override void Picked()
    {
        base.Picked();
        GameManager.gameManager.AddKey(keyColor);
    }
}
