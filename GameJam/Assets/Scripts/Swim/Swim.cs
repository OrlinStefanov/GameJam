using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fog = false;
        RenderSettings.fogColor = new Color(0.2f, 0.4f, 0.8f, 0.5f);
        RenderSettings.fogDensity = 0.05f;
    }

    bool IsUnderwater()
    {
        return transform.position.y < 19;
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.fog = IsUnderwater();
    }
}
