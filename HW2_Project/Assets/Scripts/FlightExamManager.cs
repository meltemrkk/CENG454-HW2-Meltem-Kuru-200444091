using UnityEngine;
using TMPro; // Ekrana yazý yazdýrmak için

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text missionText; // Ekranda görevi gösterecek yazý

    private bool threatCleared = false; // Füzeyi atlattý mý?
    private bool missionComplete = false; // Görev bitti mi?

    private void Start()
    {
        UpdateMissionText("Mission: Enter the Danger Zone!");
    }

    // Uçak tehlike bölgesine girdiðinde çalýþacak
    public void EnterDangerZone()
    {
        if (!missionComplete)
        {
            UpdateMissionText("Survive the Missile and Escape!");
        }
    }

    // Uçak tehlike bölgesinden çýkýp füzeyi atlattýðýnda çalýþacak
    public void ExitDangerZone()
    {
        if (!missionComplete)
        {
            threatCleared = true;
            UpdateMissionText("Threat Cleared! Return to Landing Strip.");
        }
    }

    // Uçak iniþ pistine geldiðinde çalýþacak
    public void LandAircraft()
    {
        // Sadece füzeyi atlattýysa inmesine izin ver
        if (threatCleared && !missionComplete)
        {
            missionComplete = true;
            UpdateMissionText("MISSION SUCCESSFUL! Excellent Flying.");
        }
        else if (!threatCleared && !missionComplete)
        {
            UpdateMissionText("You must clear the Danger Zone first!");
        }
    }

    private void UpdateMissionText(string message)
    {
        if (missionText != null)
        {
            missionText.text = message;
        }
    }
}