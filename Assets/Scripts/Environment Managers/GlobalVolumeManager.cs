using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlobalVolumeManager : MonoBehaviour
{
    public static GlobalVolumeManager instance;
    [SerializeField] VolumeProfile globalVolumeProfile;
    [SerializeField] ColorAdjustments colorAdjustments;
    [SerializeField] ColorCurves colorCurves;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;

        globalVolumeProfile.TryGet(out colorAdjustments);
        globalVolumeProfile.TryGet(out colorCurves);
    }

    public void SetGreyScreen()
    {
        colorAdjustments.saturation.value = -100f;
    }

    public void SetJojoScreen()
    {
        colorAdjustments.hueShift.value = 100f;
    }

    public void TwoXSpeedScreen()
    {
        colorAdjustments.postExposure.value = 3f;
        colorCurves.active = true;
    }

    public void SetDefaultScreen()
    {
        //Add default screen
        colorAdjustments.saturation.value = 0f;
        colorAdjustments.postExposure.value = 0.5f;
        colorAdjustments.hueShift.value = 0f;
        colorAdjustments.contrast.value = -6f;
        colorCurves.active = false;
    }

    private void OnApplicationQuit()
    {
        SetDefaultScreen();
    }
}
