using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text levelTime_txt;
    private float levelTime;

    public static bool stopTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTime == false)
        {
            levelTime = levelTime + Time.deltaTime;
            levelTime_txt.text = levelTime.ToString("0");
        }
    }
}
