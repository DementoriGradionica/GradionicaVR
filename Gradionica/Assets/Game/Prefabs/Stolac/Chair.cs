using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Placeable
{
    public override bool WorthPoints()
    {
        return InArea && Mathf.Round(transform.up.y * 100) < -95f;
    }
}
