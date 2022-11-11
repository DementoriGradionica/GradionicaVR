using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopPlacerment : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Laptop laptop = other.gameObject.GetComponent<Laptop>();
        if (laptop != null) {
            laptop.OnEnter();
            //Debug.Log(laptop.WorthPoints());
        }
    }

     private void OnTriggerExit(Collider other)
    {
        Laptop laptop = other.gameObject.GetComponent<Laptop>();
        if (laptop != null) {
            laptop.OnExit();
            //Debug.Log(laptop.WorthPoints());
        }
    }
}
