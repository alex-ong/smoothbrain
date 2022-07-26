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

    private float GetValue()
    {
        var tr = timeReference.GetTime();
        switch (timeType)
        {
            case TimeRef.Hour:
                return tr.Hour % 12 * 5 + 1/60f * tr.Minute + 1/3600f * tr.Second + 1/3600000f * tr.Millisecond;
            case TimeRef.Minute:
                return tr.Minute + 1/60f * tr.Second + 1/60000f * tr.Millisecond;
            case TimeRef.Second:
                return tr.Second + (1/1000f * tr.Millisecond);
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
