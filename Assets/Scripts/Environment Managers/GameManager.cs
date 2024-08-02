using GHSPG;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject gameOverMenu;
    [SerializeField] ObstaclesSpawner obstaclesSpawner;
    [SerializeField] PlatformManager platformManager;
    [SerializeField] float speedGame;
    [SerializeField] float increasingAddSpeedGame;
    public bool isGameOver;
    public bool isGamePaused;

    [Header("Debug Settings")]
    public bool isGodMode;

    public static UnityEvent<float> increasedSpeedGameEvent = new UnityEvent<float>();

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
        InvokeRepeating("IncreaseGameSpeed", 10f, 10f);

        GraphicsSettings.useScriptableRenderPipelineBatching = false;
    }

    private void IncreaseGameSpeed()
    {
        speedGame += increasingAddSpeedGame;
        increasedSpeedGameEvent.Invoke(speedGame);
    }

    public void TwoXSpeedGameMode(float coof)
    {
        speedGame *= coof;
        increasedSpeedGameEvent.Invoke(speedGame);
    }

    public void GameOver()
    {
        isGameOver = true;
        //AchievementsManager.instance.SavePlayerScore();
        //AchievementsManager.instance.SaveGameModeData();
        AchievementsManager.instance.SaveAll();
        AudioManager.instance.GameOverMenu();
        GameModeManager.instance.StopCurrentGameMode();
        PauseMenu();
    }

    public void PauseMenu()
    {
        isGamePaused = true;
        gameOverMenu.SetActive(true);
        AudioManager.instance.PauseAll();
        Time.timeScale = 0f;
    }

    public float GetSpeedGame()
    {
        return speedGame;
    }

    public void MainMenuButton()
    {
        AchievementsManager.instance.SaveAll();
        SceneManager.LoadScene(0);
        AudioManager.instance.PlayDefaultMusic();
        Time.timeScale = 1f;
    }

    public void RetryButton()
    {
        AchievementsManager.instance.SaveAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.instance.PlayDefaultMusic();
        Time.timeScale = 1f;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
