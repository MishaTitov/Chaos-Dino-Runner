using UnityEngine;

public class SuperhotGameMode : GameMode
{
    float timeReduction = 0.5f;
    float timeDefault = 1f;

    public override void SetGameMode(DinoManager dinoManager = null)
    {
        AudioManager.instance.PlayEffect(audioEffectGameMode);
        AudioManager.instance.SetMusicPitch(timeReduction);
        Time.timeScale = timeReduction;
    }

    public override void DisableGameMode()
    {
        AudioManager.instance.SetMusicPitch(timeDefault);
        AudioManager.instance.StopEffect();
        Time.timeScale = timeDefault;
    }
}
