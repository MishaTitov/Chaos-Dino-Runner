public class InvestedInCryptoGameMode : GameMode
{
    public override void SetGameMode(DinoManager dinoManager = null)
    {
        ScoreManager.instance.score = -1000000f;
        AudioManager.instance.PlayEffect(audioEffectGameMode);
    }

    public override void DisableGameMode()
    {

    }
}
