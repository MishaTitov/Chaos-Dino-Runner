using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButtonManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] TextMeshProUGUI textContinueButton;
    [SerializeField] TextMeshProUGUI modeNameTMP;
    [SerializeField] Slider modeTimerSlider;

    private void OnEnable()
    {
        //if (GameManager.instance.isGameOver)
        //{
        //    textContinueButton.text = "Continue: Ad";
        //}
        //else
        //{
        //    textContinueButton.text = "Continue";
        //}
        if (GameManager.instance.isGamePaused && !GameManager.instance.isGameOver) 
            textContinueButton.text = "Continue";
        else
            gameObject.SetActive(false);
    }

    public void ContinueButton()
    {
        //if (GameManager.instance.isGameOver)
        //{
        //    Debug.Log("See ad");
        //    AdsManager.instance.ShowRewardedAd();

        //    modeNameTMP.text = "New Mode Will Spawn in";
        //    GameModeManager.instance.timePassed = 0f;
        //    modeTimerSlider.value = modeTimerSlider.maxValue;
        //}
        //else
        //{
        //    Time.timeScale = 1f;
        //    AudioManager.instance.PlayMusic();
        //}

        Time.timeScale = 1f;
        AudioManager.instance.PlayMusic();
        gameOverMenu.SetActive(false);
        GameManager.instance.isGamePaused = false;
    }
}
