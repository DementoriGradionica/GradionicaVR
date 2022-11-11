using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Placeable
{
    public override bool WorthPoints()
    {
        return InArea;
    }
}
