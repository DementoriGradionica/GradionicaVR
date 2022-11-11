using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerStickyPlacement : MonoBehaviour
{

    private int counter=0;
    public Vector3 coordiantes;
    public Quaternion rotation;

    private void OnTriggerEnter(Collider other)
    {
        Marker marker = other.gameObject.GetComponent<Marker>();

        if(marker != null){
            if (counter == 0) {
                marker.OnEnter();
                other.transform.position = transform.parent.position + transform.TransformDirection(coordiantes);
                other.transform.rotation = transform.parent.rotation * rotation;
                other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                other.transform.GetComponent<Rigidbody>().useGravity = false;
            }

            counter++;
        }
    }

     private void OnTriggerExit(Collider other)
    {
        Marker marker = other.gameObject.GetComponent<Marker>();

        if (marker != null) {
            if(counter == 1){
                marker.OnExit();
                other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                other.transform.GetComponent<Rigidbody>().useGravity = true;
            }

            counter--; 
        }
    }
}

