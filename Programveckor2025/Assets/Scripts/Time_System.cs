using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Time_System : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextTimer;
    [SerializeField] float RemainingTime = 3600f; 

    void Update()
    {
        if (RemainingTime > 0)
        {
            RemainingTime -= Time.deltaTime;

            int hours = Mathf.FloorToInt(RemainingTime / 3600); 
            int minutes = Mathf.FloorToInt((RemainingTime % 3600) / 60); 
            int seconds = Mathf.FloorToInt(RemainingTime % 60); 

            
            TextTimer.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }
        else
        {
            TextTimer.text = "00:00:00"; 
        }

        if (RemainingTime<= 0)
        {
            NoTime();
        }
    }

    void NoTime()
    {
        SceneManager.LoadScene("Ending_GameOver");
    }
}
