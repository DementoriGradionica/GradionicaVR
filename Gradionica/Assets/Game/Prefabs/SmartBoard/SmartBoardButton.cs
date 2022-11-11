using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class SmartBoardButton : Scorable
{
    public Material On;
    public Material Off;

    public SteamVR_Action_Boolean pressed;
    public SteamVR_Input_Sources handType;
    private bool HandInArea { get; set; }
    private bool Pressed { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        pressed.AddOnStateDownListener(TriggerDown, handType);
    }
    public void TriggerDown(SteamVR_Action_Boolean pressed, SteamVR_Input_Sources fromSources)
    {
        if (HandInArea)
        {
            Pressed = !Pressed;

            if (Pressed)
            {
                transform.parent.GetComponent<MeshRenderer>().material = Off;
            }
            else 
            {
                transform.parent.GetComponent<MeshRenderer>().material = On;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<PlayerHand>() != null)
        {
            HandInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.GetComponent<PlayerHand>() != null)
        {
            HandInArea = false;
        }
    }

    public override bool WorthPoints()
    {
        return Pressed;
    }
}