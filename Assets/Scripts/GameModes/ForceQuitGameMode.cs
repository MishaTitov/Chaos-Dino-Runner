using UnityEngine;

public class ForceQuitGameMode : GameMode
{
    public override void SetGameMode(DinoManager dinoManager = null)
    {
        AudioManager.instance.PlayEffect(audioEffectGameMode);
    }

    public override void DisableGameMode()
    {
        AudioManager.instance.StopEffect();
        Application.Quit();
    }
}
