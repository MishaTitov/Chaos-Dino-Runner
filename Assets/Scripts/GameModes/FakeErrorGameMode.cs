using UnityEngine;
using UnityEngine.UI;

public class FakeErrorGameMode : GameMode
{
    [SerializeField] Sprite winXPError;

    public override void SetGameMode(DinoManager dinoManager = null)
    {
        GameCanvasManager.instance.SetSpriteImage(winXPError, true, 1.3f);
        AudioManager.instance.PlayEffect(audioEffectGameMode);
    }

    public override void DisableGameMode()
    {
        AudioManager.instance.StopEffect();
        GameCanvasManager.instance.SetSpriteImage(null, false, 3/10f);
    }
}
