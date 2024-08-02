using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager instance;
    [SerializeField] DinoManager dinoManager;
    [SerializeField] TextMeshProUGUI modeNameTMP;
    [SerializeField] Slider modeTimerSlider;
    [Header("Game Mode Settings")]
    [SerializeField] GameMode[] gameModes;
    [SerializeField] string nameGameMode;
    [SerializeField] float durationGameMode;
    [SerializeField] float repeatRateMode = 10f;
    public float timePassed;
    [Header("Debug Settings")]
    [SerializeField] int indexRandomMode;
    [SerializeField] bool isDebugMode;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        modeTimerSlider.value = repeatRateMode;
    }

    private void Update()
    {
        if (timePassed < durationGameMode)
            timePassed += Time.deltaTime;
        else
        {
            gameModes[indexRandomMode].DisableGameMode();
            poolNewMode();
            timePassed = 0f;
        }
        modeTimerSlider.value -= Time.deltaTime;
    }

    private void poolNewMode()
    {
        if (!isDebugMode)
            indexRandomMode = Random.Range(0, gameModes.Length);
        nameGameMode = gameModes[indexRandomMode].GetNameGameMode();
        durationGameMode = gameModes[indexRandomMode].GetDurationGameMode();

        modeTimerSlider.maxValue = durationGameMode;
        modeTimerSlider.value = durationGameMode;
        modeNameTMP.text = nameGameMode;

        gameModes[indexRandomMode].SetGameMode(dinoManager);

        AchievementsManager.instance.StoreGameModeData(nameGameMode);
    }

    public void StopCurrentGameMode()
    {
        gameModes[indexRandomMode].DisableGameMode();
    }

    public string GetNameGameMode()
    {
        return nameGameMode;
    }
}
