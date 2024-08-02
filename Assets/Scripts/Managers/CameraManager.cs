using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    [Range(0f,0.1f)]
    [SerializeField] float magnitude;
    //[SerializeField] RenderTexture pixelatedRenderTexture;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public void StartShakeCamera(float timeDuration)
    {
        StartCoroutine(nameof(ShakeCamera), timeDuration);
    }

    IEnumerator ShakeCamera(float timeDuration)
    {
        Vector3 originalPosition = transform.localPosition;
        float timePassed = 0f;
        while(timePassed < timeDuration)
        {
            float x = Random.Range(-1f,1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPosition + new Vector3(x, y, 0f);
            timePassed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPosition;
    }

    public void SetRenderTexture(RenderTexture renderTexture = null)
    {
        Camera.main.targetTexture = renderTexture;
    }
}
