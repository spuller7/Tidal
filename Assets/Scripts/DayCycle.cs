using UnityEngine;
using System.Collections;

public class DayCycle : MonoBehaviour
{

    public Light sun;
    public float normalSpeed = 80f;
    public float fastSpeed = 25f;

    public float secondsInFullDay = 80f;
    [Range(0, 1)]
    public float currentTimeOfDay = 0;
    [HideInInspector]
    public float timeMultiplier = 1f;

    float sunInitialIntensity;

    void Start()
    {
        sunInitialIntensity = sun.intensity;
    }

    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            secondsInFullDay = fastSpeed;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            secondsInFullDay = normalSpeed;
        }

    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
    }
}