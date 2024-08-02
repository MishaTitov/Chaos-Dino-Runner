using UnityEngine;

public class GoogleChromeGameMode : GameMode
{
    [SerializeField] Vector3 previousCameraPosition;
    [SerializeField] Quaternion previousCameraRotation;

    public override void SetGameMode(DinoManager dinoManager = null)
    {
        Camera.main.orthographic = true;
        previousCameraPosition = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(12f, 2f, -4f);
        previousCameraRotation = Camera.main.transform.rotation;
        Camera.main.transform.rotation = Quaternion.identity;
    }

    public override void DisableGameMode()
    {
        Camera.main.orthographic = false;
        Camera.main.usePhysicalProperties = true;
        Camera.main.transform.position = previousCameraPosition;
        Camera.main.transform.rotation = previousCameraRotation;
    }
}
