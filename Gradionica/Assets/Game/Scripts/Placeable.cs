using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : Scorable
{

    public bool InArea { get; set; }

    public void OnEnter()
    {
        InArea = true;
    }


    public void OnExit()
    {
        InArea = false;
    }

}
