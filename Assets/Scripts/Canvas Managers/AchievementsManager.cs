using System.Collections.Generic;
using UnityEngine;



public class AchievementsManager : MonoBehaviour
{
    public static AchievementsManager instance;

    [SerializeField] GameObject content;
    public Dictionary<string, int> achievementsData;
    public int highScore;
    public int lowScore;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        achievementsData = new Dictionary<string, int>();
        LoadPlayerScore();
    }

    private void OnApplicationQuit()
    {
        SavePlayerScore();
        SaveGameModeData();
    }

    #region PlayerPrefs
    public void SavePlayerScore()
    {
        if (ScoreManager.instance == null)
            return;

        int curScores = (int)ScoreManager.instance.score;
        if (highScore < curScores)
        {
            highScore = curScores;
            PlayerPrefs.SetInt("High Score", highScore);
            PlayerPrefs.Save();
        }

        if (lowScore > curScores)
        {
            lowScore = curScores;
            PlayerPrefs.SetInt("Low Score", lowScore);
            PlayerPrefs.Save();
        }
    }

    private void LoadPlayerScore()
    {
        highScore = PlayerPrefs.GetInt("High Score", 0);

        lowScore = PlayerPrefs.GetInt("Low Score", 0);
    }

    public void StoreGameModeData(string nameGameMode)
    {
        LoadGameModeData(nameGameMode);
        achievementsData[nameGameMode] += 1;
    }

    public void SaveGameModeData()
    {
        foreach (var kvp in achievementsData)
        {
            PlayerPrefs.SetInt(kvp.Key, kvp.Value);
        }
        PlayerPrefs.Save();
    }

    public void SaveAll()
    {
        SavePlayerScore();
        SaveGameModeData();
    }

    public int LoadGameModeData(string nameGameMode)
    { 
        achievementsData[nameGameMode] = PlayerPrefs.GetInt(nameGameMode, 0);
        return achievementsData[nameGameMode];
    }
    #endregion
}
