public class JojoScreenGameMode : GameMode
{
    public override void SetGameMode(DinoManager dinoManager = null)
    {
        GlobalVolumeManager.instance.SetJojoScreen();
        AudioManager.instance.PlayMusic(musicGameMode);
    }

    public override void DisableGameMode()
    {
        GlobalVolumeManager.instance.SetDefaultScreen();
        AudioManager.instance.PlayDefaultMusic();
    }
}
