using UnityEngine;

public class GTA2GameMode : GameMode
{
    [SerializeField] Vector3 previousCameraPosition;
    [SerializeField] Quaternion previousCameraRotation;

    public override void SetGameMode(DinoManager dinoManager = null)
    {
        Camera.main.orthographic = true;
        previousCameraPosition = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(12f, 20f, 0f);
        previousCameraRotation = Camera.main.transform.rotation;
        Camera.main.transform.rotation = Quaternion.Euler(90f,0f,0f);
        AudioManager.instance.PlayEffect(audioEffectGameMode);
    }

    public override void DisableGameMode()
    {
        Camera.main.orthographic = false;
        Camera.main.usePhysicalProperties = true;
        Camera.main.transform.position = previousCameraPosition;
        Camera.main.transform.rotation = previousCameraRotation;
    }
}
