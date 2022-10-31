using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeSinceStartup : MonoBehaviour
{
    [SerializeField]
    public TMP_Text text;

    [SerializeField]
    public TimeOfDay time;

    // Start is called before the first frame update
    void Start() { }

    private string Padder(int value, int dp)
    {
        return value.ToString().PadLeft(dp, '0');
    }

    // Update is called once per frame
    void Update()
    {
        var tr = time.GetTime();
        var hour = Padder(tr.Hour, 2);
        var minute = Padder(tr.Minute, 2);
        var second = Padder(tr.Second, 2);
        var millis = Padder(tr.Millisecond, 3);

        text.text = $"{hour}:{minute}:{second}.{millis}";
    }
}
