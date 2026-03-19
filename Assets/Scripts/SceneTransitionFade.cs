using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionFade : MonoBehaviour
{
    public Image fadeImage; // 黑屏的 Image 组件
    public Text textWaiting; // text_waiting 的 Text 组件
    public float fadeInTime = 1f; // 淡入时间
    public float fadeOutTime = 1f; // 淡出时间

    private void Start()
    {
        // 初始时黑屏和文本完全透明
        SetAlpha(fadeImage, 0f);
        SetAlpha(textWaiting, 0f);
    }

    // 设置 UI 元素的透明度
    private void SetAlpha(Graphic graphic, float alpha)
    {
        Color color = graphic.color;
        color.a = alpha;
        graphic.color = color;
    }

    // 淡入黑屏并显示文本
    public IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeInTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);
            SetAlpha(fadeImage, alpha);
            SetAlpha(textWaiting, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SetAlpha(fadeImage, 1f);
        SetAlpha(textWaiting, 1f);
    }

    // 黑屏和文本淡出
    public IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeOutTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutTime);
            SetAlpha(fadeImage, alpha);
            SetAlpha(textWaiting, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SetAlpha(fadeImage, 0f);
        SetAlpha(textWaiting, 0f);
    }
}