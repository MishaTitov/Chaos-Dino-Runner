public class GreyScreenGameMode : GameMode
{
    public override void SetGameMode(DinoManager dinoManager = null)
    {
        GlobalVolumeManager.instance.SetGreyScreen();
    }

    public override void DisableGameMode()
    {
        GlobalVolumeManager.instance.SetDefaultScreen();
    }
}
