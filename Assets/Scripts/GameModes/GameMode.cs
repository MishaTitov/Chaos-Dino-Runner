using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField] protected string nameGameMode;
    [SerializeField] protected float durationGameMode;
    [SerializeField] protected AudioClip audioEffectGameMode;
    [SerializeField] protected AudioClip musicGameMode;

    public string GetNameGameMode()
    {
        return nameGameMode;
    }

    public float GetDurationGameMode()
    {
        return durationGameMode;
    }

    public virtual void SetGameMode(DinoManager dinoManager = null)
    {
        Debug.Log(nameGameMode + " setted, duration = " + durationGameMode);
    }

    public virtual void DisableGameMode()
    {
        Debug.Log(nameGameMode + " disabled");
    }
}