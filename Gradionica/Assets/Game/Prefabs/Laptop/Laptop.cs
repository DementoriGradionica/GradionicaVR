using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : Placeable
{
    public override bool WorthPoints() {
        return InArea;
    }
}
