using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class LightSwitchButton : Scorable
{
    public SteamVR_Action_Boolean pressed;
    public SteamVR_Input_Sources handType;
    private bool HandInArea { get; set; }
    private bool Pressed { get; set; }
    public List<Transform> lights;


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
                foreach (Transform light in lights)
                {
                    int lightComponents = light.childCount;
                    for (int i = 0; i < lightComponents; i++)
                    {
                        if (light.GetChild(i).transform.GetComponent<Light>() != null)
                        {
                            light.GetChild(i).transform.GetComponent<Light>().enabled = false;

                            ScoringManager.instance.LightState(false);
                        }
                    }
                }
            }
            else
            {
                foreach (Transform light in lights)
                {
                    int lightComponents = light.childCount;
                    for (int i = 0; i < lightComponents; i++)
                    {
                        if (light.GetChild(i).transform.GetComponent<Light>() != null)
                        {
                            light.GetChild(i).transform.GetComponent<Light>().enabled = true;

                            ScoringManager.instance.LightState(true);
                        }
                    }
                }
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
