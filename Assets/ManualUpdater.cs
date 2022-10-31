using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualUpdater : MonoBehaviour
{
    [SerializeField]
    protected List<AbstractManualMono> items = new();

    [SerializeField]
    public float FPS = 0f;
    public float nextUpdate = 0f;

    // Start is called before the first frame update
    void Start() { }

    void DoUpdate()
    {
        foreach (var item in items)
        {
            item.ManualUpdate();
        }
    }

    float UpdateInterval()
    {
        if (FPS <= 0)
        {
            return 0;
        }
        return 1 / FPS;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextUpdate <= Time.time)
        {
            nextUpdate += UpdateInterval();
            DoUpdate();
        }
    }
}
