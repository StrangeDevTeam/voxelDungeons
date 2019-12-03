using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float speed = 0.1f; // the default dayNightCycleSpeed

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(speed, 0, 0);
    }
}
