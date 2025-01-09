using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Time_System : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextTimer; 
    [SerializeField] float RemainingTime = 300f; 

    void Update()
    {
        if (RemainingTime > 0)
        {
            RemainingTime -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(RemainingTime / 60);
            int seconds = Mathf.FloorToInt(RemainingTime % 60);

            TextTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            TextTimer.text = "00:00"; 
        }
    }
}
