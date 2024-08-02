using UnityEngine;

public class NoScoreGameMode : GameMode
{
    public override void SetGameMode(DinoManager dinoManager = null)
    {
        ScoreManager.instance.enabled = false;
    }

    public override void DisableGameMode()
    {
        ScoreManager.instance.enabled = true;
    }
}
