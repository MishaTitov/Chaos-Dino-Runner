using UnityEngine;

public class MiniDinoGameMode : GameMode
{
    public override void SetGameMode(DinoManager dinoManager = null)
    {
        dinoManager.StartMiniDino(durationGameMode);
    }

    public override void DisableGameMode()
    {
        
    }
}
