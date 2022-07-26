using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDay : MonoBehaviour
{
    [SerializeField] private DateTime dt = DateTime.Now;
    public DateTime GetTime()
    {
        return dt;
    }

    [SerializeField] private int hours = 0;
    [SerializeField] private int minutes = 0;
    [SerializeField] private bool ShowGUI = false;

    // Update is called once per frame
    void Update()
    {
        dt = DateTime.Now;
        dt = dt.AddHours(hours);
        dt = dt.AddMinutes(minutes);
    }

    private void OnGUI()
    {
        if (!ShowGUI) return;
        if (GUI.Button(new Rect(0,0,100,30), "Add Hour"))
        {
            hours++;
        }
        if (GUI.Button(new Rect(100, 0, 100, 30), "Sub Hour"))
        {
            hours--;
        }

        if (GUI.Button(new Rect(0, 30, 100, 30), "Add Minute"))
        {
            minutes++;
        }
        if (GUI.Button(new Rect(100, 30, 100, 30), "Sub Minute"))
        {
            minutes--;
        }
    }
}
