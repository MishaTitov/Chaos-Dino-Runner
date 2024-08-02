using UnityEngine;

public class GodGameMode : GameMode
{
    private void Awake()
    {
        nameGameMode = "GodMode";
        durationGameMode = 10f;
    }

    public override void SetGameMode(DinoManager dinoManager = null)
    {
        GameManager.instance.isGodMode = true;
    }

    public override void DisableGameMode()
    {
        GameManager.instance.isGodMode = false;
    }
}
