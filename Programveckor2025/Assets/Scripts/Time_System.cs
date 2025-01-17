using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Time_System : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextTimer;
    [SerializeField] float RemainingTime = 600f;

    public int totalNPCs = 20; // Total NPCs in the game (adjust as needed)
    private int talkedToNPCs = 0; // Count of NPCs the player has talked to
    public string goodEndingScene = "Ending_Good";
    public string badEndingScene = "Ending_Bad";

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
            NoTime();
        }
    }

    void NoTime()
    {
        if (talkedToNPCs >= totalNPCs)
        {
            SceneManager.LoadScene("GoodEnding"); // Load the good ending
        }
        else
        {
            SceneManager.LoadScene("Ending_GameOver"); // Load the bad ending
        }
    }


    public void RegisterNPCInteraction()
    {
        if (talkedToNPCs < totalNPCs)
        {
            talkedToNPCs++;
        }
    }
}
