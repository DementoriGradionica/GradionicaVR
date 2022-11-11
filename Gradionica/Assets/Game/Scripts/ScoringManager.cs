using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoringManager : MonoBehaviour
{
    public static ScoringManager instance;
    [SerializeField] private List<Scorable> scorables;
    public GameObject gradionica;
    private int Lights;
    private int LightOff;

    void Awake()
    {
        Lights = 0;
        LightOff = 0;

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        Instantiate(gradionica, new Vector3(0, 0, 0), Quaternion.identity);
        RenderSettings.ambientSkyColor = new Color(200f / 255f, 200f / 255f, 200f / 255f);
        RenderSettings.ambientGroundColor = new Color(200f / 255f, 200f / 255f, 200f / 255f);
    }

    public void AddScorable(Scorable scorable)
    {
        scorables.Add(scorable);
    }

    public void RemoveScorable(Scorable scorable)
    {
        scorables.Remove(scorable);
    }

    public string CheckScore()
    {
        if (scorables != null)
        {
            List<Scorable> correct = scorables.Where(x => x.WorthPoints()).ToList();

            return (correct.Count.ToString() + "/" + scorables.Count.ToString());
        }
        return "No info";
    }

    public void Mrak()
    {
        Lights++;
    }

    public void LightState(bool state)
    {
        if (!state) LightOff++;
        else LightOff--;

        var LightLeve = (80f + 120f * (1f - (float)LightOff / (float)Lights))/255f;
        RenderSettings.ambientSkyColor = new Color(LightLeve, LightLeve, LightLeve);
        RenderSettings.ambientGroundColor = new Color(LightLeve, LightLeve, LightLeve);
    }
}
