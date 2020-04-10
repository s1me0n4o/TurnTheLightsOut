using System.Collections;
using UnityEngine;

public class FaderUI : MonoBehaviour
{
    public static FaderUI Instance;

    public float fadeOutSeconds = 3f;
    public float fadeInSeconds = 1f;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        #region Singalton
        if (Instance != null)
        {
            GameObject.Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
        #endregion
    }          

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public IEnumerator FadeOutIn()
    {
        yield return FadeOut(fadeOutSeconds);
        yield return FadeIn(fadeInSeconds);
    }

    private IEnumerator FadeOut(float time)
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / time;
            yield return null;
        }
    }
    private IEnumerator FadeIn(float time)
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }
}
