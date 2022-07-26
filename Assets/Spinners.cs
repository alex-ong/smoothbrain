using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinners : MonoBehaviour
{
    [SerializeField] private float numerator = 1f;
    [SerializeField] private float denominator = 3f;
    [SerializeField] public TimeOfDay timeReference;

    public enum TimeRef
    {
        Hour,
        Minute,
        Second
    }
    public TimeRef timeType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    const int HOUR_TO_SIXTY = 5;
    const float MINUTE_PER_HOUR = 60f;
    const float SECOND_PER_MINUTE = 60f;
    const float SECOND_PER_HOUR = MINUTE_PER_HOUR * SECOND_PER_MINUTE; //3600f
    const float MILLIS_PER_SECOND = 1000f;
    const float MILLIS_PER_MINUTE = MILLIS_PER_SECOND*SECOND_PER_MINUTE;
    const float MILLIS_PER_HOUR = MILLIS_PER_SECOND * SECOND_PER_HOUR; //3600000f

    /// <summary>
    /// Returns value from [0,60)
    /// </summary>
    /// <returns></returns>
    private float GetValue()
    {
        var tr = timeReference.GetTime();
        switch (timeType)
        {
            case TimeRef.Hour:
                return HOUR_TO_SIXTY * ((tr.Hour) 
                    + (tr.Minute/MINUTE_PER_HOUR) 
                    + (tr.Second/SECOND_PER_HOUR) 
                    + (tr.Millisecond/MILLIS_PER_HOUR));
            case TimeRef.Minute:
                return tr.Minute 
                    + (tr.Second/SECOND_PER_MINUTE)
                    + (tr.Millisecond/MILLIS_PER_MINUTE);
            case TimeRef.Second:
                return tr.Second 
                    + (tr.Millisecond/MILLIS_PER_SECOND);
            default:
                return tr.Second;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.localEulerAngles = new Vector3(0, 0, 90 -GetValue() * (numerator/denominator));
    }
}
