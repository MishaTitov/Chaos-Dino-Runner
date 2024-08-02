using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject loaderLevelCanvas;
    [SerializeField] Slider loaderLevelSlider;

    public void LoadLevel(int indexScene)
    {
        StartCoroutine(LoadAsynchronously(indexScene));
    }

    IEnumerator LoadAsynchronously(int indexScene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(indexScene);
        //Loading Screne
        loaderLevelCanvas.SetActive(true);
        float progress;
        while (!asyncOperation.isDone)
        {
            progress = Mathf.Clamp01(asyncOperation.progress / .9f);
            loaderLevelSlider.value = progress;
            yield return null;
        }
    }
}
