using UnityEngine;

public class PixelatedScreenGameMode : GameMode
{
    [SerializeField] RenderTexture pixelatedRenderTexture;

    public override void SetGameMode(DinoManager dinoManager = null)
    {
        AudioManager.instance.PlayMusic(musicGameMode);
        GameCanvasManager.instance.SetPixelatedScreen(true);
        CameraManager.instance.SetRenderTexture(pixelatedRenderTexture);
    }

    public override void DisableGameMode()
    {
        AudioManager.instance.PlayDefaultMusic();
        GameCanvasManager.instance.SetPixelatedScreen(false);
        CameraManager.instance.SetRenderTexture();
    }
}
