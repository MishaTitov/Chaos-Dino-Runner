using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuManager : MonoBehaviour
{
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider effectsVolumeSlider;

    private void OnEnable()
    {
        musicVolumeSlider.value = AudioManager.instance.GetMusicVolume();
        effectsVolumeSlider.value = AudioManager.instance.GetEffectsVolume();
    }
}
