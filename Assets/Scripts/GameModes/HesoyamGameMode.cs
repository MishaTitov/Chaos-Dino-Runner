public class HesoyamGameMode : GameMode
{
    public override void SetGameMode(DinoManager dinoManager = null)
    {
        // Maybe Add lifes?
        ScoreManager.instance.score += 250000f;
        AudioManager.instance.PlayEffect(audioEffectGameMode);
    }

    public override void DisableGameMode()
    {

    }
}
