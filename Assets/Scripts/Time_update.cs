using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Time_update : MonoBehaviour
{
    public TextMeshProUGUI time_counter;
    public bool racing = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (racing)
        {
            float tmp = Time.timeSinceLevelLoad;
            time_counter.text = tmp.ToString("0.000");

        }
    }
}
