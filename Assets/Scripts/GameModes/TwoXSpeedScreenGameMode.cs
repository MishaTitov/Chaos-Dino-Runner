using UnityEngine;
using UnityEngine.Rendering;

public class TwoXSpeedScreenGameMode: GameMode
{
    [SerializeField] float timeToStartPlayMusic;

    public override void SetGameMode(DinoManager dinoManager = null)
    {
        GlobalVolumeManager.instance.TwoXSpeedScreen();
        GameManager.instance.TwoXSpeedGameMode(2f);
        AudioManager.instance.PlayMusic(musicGameMode, timeToStartPlayMusic);
    }

    public override void DisableGameMode()
    {
        GameManager.instance.TwoXSpeedGameMode(0.5f);
        AudioManager.instance.PlayDefaultMusic();
        GlobalVolumeManager.instance.SetDefaultScreen();
    }
}
