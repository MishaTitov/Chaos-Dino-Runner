using UnityEngine;

public class ClearEffectGameMode : GameMode
{
    private void Awake()
    {
        nameGameMode = "ClearEffectGameMode";
        durationGameMode = 10f;
    }

    public override void SetGameMode(DinoManager dinoManager = null)
    {

    }

    public override void DisableGameMode()
    {

    }
}
