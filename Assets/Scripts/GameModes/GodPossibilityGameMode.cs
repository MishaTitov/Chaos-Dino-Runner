using UnityEngine;

public class GodPossibilityGameMode : GameMode
{
    [SerializeField] float timeToPlayEffect;
    [Range(0,1)]
    [SerializeField] float possibilityThreshold;
    private void Awake()
    {
        nameGameMode = "GodMode?";
        durationGameMode = 10f;
    }

    public override void SetGameMode(DinoManager dinoManager = null)
    {
        AudioManager.instance.StartFadeEffect(audioEffectGameMode, timeToPlayEffect);
        if (possibilityThreshold > Random.Range(0f,1f))
            GameManager.instance.isGodMode = true;
    }

    public override void DisableGameMode()
    {
        GameManager.instance.isGodMode = false;
    }
}
