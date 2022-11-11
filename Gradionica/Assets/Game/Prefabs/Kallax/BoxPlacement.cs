using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPlacement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Box box = other.gameObject.GetComponent<Box>();
        if (box != null)
        {
            box.OnEnter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Box box = other.gameObject.GetComponent<Box>();
        if (box != null)
        {
            //box.transform.position
            box.OnExit();
        }
    }
}
