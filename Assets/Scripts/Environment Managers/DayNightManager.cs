using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    public static DayNightManager instance;

    [SerializeField] Light sunLight;
    [SerializeField] Light moonLight;
    [SerializeField] Material skyboxSun;
    [SerializeField] Material skyboxMoon;
    [SerializeField] ParticleSystem starsSky;
    ParticleSystem.EmissionModule emissionModule;

    [Range(0,1)]
    [SerializeField] float timeOfDay;
    [SerializeField] public float dayDuration = 30f;
    [SerializeField] float angleInSeconds;

    [SerializeField] AnimationCurve sunLightIntensityCurve;
    [SerializeField] AnimationCurve moonLightIntensityCurve;
    [SerializeField] AnimationCurve skyboxCurve;

    private float defaultSunIntensity;
    private float defaultMoonIntensity;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;

        emissionModule = starsSky.emission;
        starsSky.Stop();
        emissionModule.enabled = false;
    }

    private void Start()
    {
        defaultSunIntensity = sunLight.intensity;
        defaultMoonIntensity = moonLight.intensity;
    }


    private void Update()
    {
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay > 1) timeOfDay -= 1;
        angleInSeconds = 360f / dayDuration;

        RenderSettings.skybox.Lerp(skyboxMoon, skyboxSun, skyboxCurve.Evaluate(timeOfDay));
        RenderSettings.sun = skyboxCurve.Evaluate(timeOfDay) > 0.1f ? sunLight : moonLight;
        DynamicGI.UpdateEnvironment();

        if (starsSky.isStopped && timeOfDay > 0.45f)
        {
            starsSky.Play();
            emissionModule.enabled = true;

        }
        else if (starsSky.isPlaying && timeOfDay <= 0.45f)
        {
            starsSky.Stop();
            starsSky.Clear();
            emissionModule.enabled = false;
        }

        sunLight.transform.RotateAround(transform.position, new Vector3(-0.75f, 1f,0f), angleInSeconds * Time.deltaTime);
        // TODO RETURN MOON TO DEFAULT TRANSFORM
        //moonLight.transform.RotateAround(transform.position, new Vector3(-0.75f, 1f, 0f), angleInSeconds * Time.deltaTime);

        sunLight.intensity = defaultSunIntensity * sunLightIntensityCurve.Evaluate(timeOfDay);
        moonLight.intensity = defaultMoonIntensity * moonLightIntensityCurve.Evaluate(timeOfDay);
    }
}
