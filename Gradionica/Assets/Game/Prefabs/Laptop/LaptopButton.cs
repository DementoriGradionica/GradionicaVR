using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class LaptopButton : Scorable
{

    public SteamVR_Action_Boolean pressed;
    public SteamVR_Input_Sources handType;
    private bool HandInArea { get; set; }
    private bool Pressed { get; set; }
    public Transform lid;


    void Start()
    {
        pressed.AddOnStateDownListener(TriggerDown, handType);
    }


    public void TriggerDown(SteamVR_Action_Boolean pressed, SteamVR_Input_Sources fromSources)
    {
        if(HandInArea) {
            //Debug.Log(Pressed);
            Pressed = !Pressed;

            if(Pressed) {
                lid.GetComponent<Animator>().Play("Laptop closeing");
            } else {
                lid.GetComponent<Animator>().Play("Laptop opening");
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<PlayerHand>() != null) {
            HandInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.GetComponent<PlayerHand>() != null) {
            HandInArea = false;
        }
    }

        public override bool WorthPoints() {
            return Pressed;
    }
}
