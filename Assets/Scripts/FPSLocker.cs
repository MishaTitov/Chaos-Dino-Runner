using UnityEngine;
using UnityEngine.Rendering;

public class FPSLocker : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
