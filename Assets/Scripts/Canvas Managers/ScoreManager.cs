using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] TextMeshProUGUI highScoreTMP;
    // Find way to acces only for modes
    public float score;
    [SerializeField] float increasingAddScore = 10f;

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
        highScoreTMP.text = "HI " + AchievementsManager.instance.highScore.ToString();
    }

    private void OnEnable()
    {
        GameManager.increasedSpeedGameEvent.AddListener(increasedSpeedGame);
    }

    void Update()
    {
        HandleScores();
    }

    private void HandleScores()
    {
        score += Time.deltaTime * increasingAddScore;
        scoreTMP.text = ((int)score).ToString();
    }

    private void increasedSpeedGame(float newSpeedGame)
    {
        increasingAddScore += 2f;
    }
}
