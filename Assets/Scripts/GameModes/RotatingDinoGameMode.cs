public class RotatingDinoGameMode : GameMode
{
    public override void SetGameMode(DinoManager dinoManager = null)
    {
        dinoManager.StartRotateDino(durationGameMode);
    }

    public override void DisableGameMode()
    {

    }
}