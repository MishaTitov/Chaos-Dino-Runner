using UnityEngine;

public class ForceAdGameMode : GameMode
{
    public override void SetGameMode(DinoManager dinoManager = null)
    {
        base.SetGameMode();
        AdsManager.instance.ShowRewardedAd();
    }

    public override void DisableGameMode()
    {
        base.DisableGameMode();
    }
}
