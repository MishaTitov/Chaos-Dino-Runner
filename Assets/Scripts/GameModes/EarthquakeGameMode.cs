using UnityEngine;

public class EarthquakeGameMode : GameMode
{
    public override void SetGameMode(DinoManager dinoManager = null)
    {
        CameraManager.instance.StartShakeCamera(durationGameMode);
    }

    public override void DisableGameMode()
    {
        CameraManager.instance.StopAllCoroutines();
    }
}
