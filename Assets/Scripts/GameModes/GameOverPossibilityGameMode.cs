using UnityEngine;

public class GameOverPossibilityGameMode : GameMode
{
    [SerializeField] float timeToPlayEffect;
    [Range(0, 1)]
    [SerializeField] float possibilityGameOver;

    public override void SetGameMode(DinoManager dinoManager = null)
    {
        AudioManager.instance.StartFadeEffect(audioEffectGameMode, timeToPlayEffect);
        if (possibilityGameOver > Random.Range(0f, 1f))
            GameManager.instance.GameOver();
    }

    public override void DisableGameMode()
    {

    }
}
