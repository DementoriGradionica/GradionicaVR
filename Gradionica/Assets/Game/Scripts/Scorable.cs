using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scorable : MonoBehaviour
{

    public virtual bool WorthPoints()
    {
        return false;
    }

    void OnDisable()
    {
        ScoringManager.instance.RemoveScorable(this);
    }

    void OnEnable()
    {
        ScoringManager.instance.AddScorable(this);
    }
}
