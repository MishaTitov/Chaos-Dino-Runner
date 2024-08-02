using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuButtons;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject achievementsMenu;

    public void AchievementsButton()
    {
        mainMenuButtons.SetActive(false);
        achievementsMenu.SetActive(true);
    }

    public void OptionsButton()
    {
        mainMenuButtons.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void BackButton()
    {
        achievementsMenu.SetActive(false);
        optionsMenu.SetActive(false);
        mainMenuButtons.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void SetMusicVolume(float value)
    {
        AudioManager.instance.SetMusicVolume(value);
    }

    public void SetEffectsVolume(float value)
    {
        AudioManager.instance.SetEffectsVolume(value);
    }
}
