using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : Placeable
{
    public override bool WorthPoints() {
        return InArea;
    }
}
