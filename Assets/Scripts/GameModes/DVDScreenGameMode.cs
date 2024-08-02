using UnityEngine;

public class DVDScreenGameMode : GameMode
{
    [SerializeField] Sprite DVDLogo;

    public override void SetGameMode(DinoManager dinoManager = null)
    {
        GameCanvasManager.instance.SetSpriteImage(DVDLogo, true);
        GameCanvasManager.instance.StartDVDScreen();
        Invoke(nameof(DisableGameMode), durationGameMode);
    }

    public override void DisableGameMode()
    {
        GameCanvasManager.instance.StopDVDScreen();
    }
}
