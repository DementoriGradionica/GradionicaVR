using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairPlacement : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Chair chair = other.gameObject.GetComponent<Chair>();
        if (chair != null)
        {
            chair.OnEnter();
            //Debug.Log(chair.WorthPoints());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Chair chair = other.gameObject.GetComponent<Chair>();
        if (chair != null)
        {
            chair.OnExit();
            //Debug.Log(chair.WorthPoints());
        }
    }
}
