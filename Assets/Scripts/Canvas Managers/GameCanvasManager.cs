using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasManager : MonoBehaviour
{
    public static GameCanvasManager instance;

    [SerializeField] Image GameModeImage;
    [SerializeField] RawImage pixelatedRTRawImage;
    [SerializeField] Vector3[] pathDVDPoints;
    [SerializeField] float duration;
    Vector3 origianlPosition;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        origianlPosition = GameModeImage.transform.localPosition;
    }

    public void SetPixelatedScreen(bool isActive)
    {
        pixelatedRTRawImage.enabled = isActive;
    }

    public void SetSpriteImage(Sprite spriteToSet, bool isActive, float ratioScale = 1.2f)
    {
        GameModeImage.transform.localScale = Vector3.one * ratioScale;
        GameModeImage.sprite = spriteToSet;
        GameModeImage.enabled = isActive;
    }

    #region DVD Screen
    public void StopDVDScreen()
    {
        StopAllCoroutines();
        GameModeImage.color = Color.white;
        GameModeImage.transform.localPosition = origianlPosition;
        GameModeImage.enabled = false;
    }

    public void StartDVDScreen()
    {
        StartCoroutine(nameof(FollowPath));
    }

    IEnumerator FollowPath()
    {
        int index = Random.Range(0,4);
        while (true)
        {
            // pause coroutine until "Move" has finnished running
            yield return StartCoroutine(Move(pathDVDPoints[index]));
            ++index;
            if (index == 4)
                index = 0;
        }
    }

    IEnumerator Move(Vector3 dest)
    {
        float timePassed = 0f;
        Vector3 startPosition = GameModeImage.transform.localPosition;
        GameModeImage.color = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f));
        while (timePassed < duration)
        {
            GameModeImage.transform.localPosition = Vector3.Lerp(startPosition, dest, timePassed / duration);
            timePassed += Time.deltaTime;
            // pause coroutine until next frame
            yield return null;
        }
    }
    #endregion
}
