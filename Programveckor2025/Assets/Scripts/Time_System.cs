using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Time_System : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextTimer;
    [SerializeField] float RemainingTime = 600f;

    public int totalNPCs = 3;  // Total number of NPCs
    private int talkedToNPCs = 0;  // Number of NPCs talked to
    private int completedQuests = 0;  // Number of completed quests
    public string goodEndingScene = "GoodEnding";
    public string badEndingScene = "Ending_GameOver";

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
        if (talkedToNPCs >= totalNPCs && completedQuests == totalNPCs)  // Check if all NPCs are talked to and all quests are completed
        {
            SceneManager.LoadScene("GoodEnding"); // Load the good ending
        }
        else
        {
            SceneManager.LoadScene("Ending_GameOver"); // Load the bad ending
        }
    }

    // This function is called when an NPC interaction occurs
    public void RegisterNPCInteraction(bool hasCompletedQuest)
    {
        if (talkedToNPCs < totalNPCs)
        {
            talkedToNPCs++;

            // If the quest is completed, increment the completed quests
            if (hasCompletedQuest)
            {
                completedQuests++;
            }

            Debug.Log($"Interacted with {talkedToNPCs}/{totalNPCs} NPCs, Completed {completedQuests}/{totalNPCs} quests");
        }
    }
}
