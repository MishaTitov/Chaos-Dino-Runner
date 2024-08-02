public class NoGravityGameMode : GameMode
{
    public override void SetGameMode(DinoManager dinoManager = null)
    {
        AudioManager.instance.PlayMusic(musicGameMode);
        dinoManager.StartNoGravity(durationGameMode);
    }

    public override void DisableGameMode()
    {
        AudioManager.instance.PlayDefaultMusic();
    }
}
