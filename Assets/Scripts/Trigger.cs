using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public string name;
    public Image waitingWait;
    public Text waitingText;
    public float fadeInTime = 1f; // 淡入时间
    public float fadeOutTime = 1f; // 淡出时间
    public float waitTimeAfterFadeIn = 0.5f; // 淡入完成后等待的时间，确保场景加载完成

    private void Start()
    {
        // 初始时将黑屏和文本的透明度设为 0 并禁用
        SetAlpha(waitingWait, 0f);
        SetAlpha(waitingText, 0f);
        waitingWait.enabled = false;
        waitingText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 假设角色的标签是 "Player"
        {
            StartCoroutine(TransitionScene());
        }
    }

    IEnumerator TransitionScene()
    {
        // 启用黑屏和文本
        waitingWait.enabled = true;
        waitingText.enabled = true;

        // 淡入效果
        yield return StartCoroutine(FadeIn());

        // 异步加载场景
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);
        asyncLoad.allowSceneActivation = false; // 阻止场景自动激活

        // 等待场景加载完成
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f) // 当加载进度达到 0.9 时，认为场景基本加载完成
            {
                asyncLoad.allowSceneActivation = true; // 允许场景激活
            }
            yield return null;
        }

        // 淡入完成后等待一段时间，确保场景完全加载和切换
        yield return new WaitForSeconds(waitTimeAfterFadeIn);

        // 淡出效果
        yield return StartCoroutine(FadeOut());

        // 禁用黑屏和文本
        waitingWait.enabled = false;
        waitingText.enabled = false;
    }

    // 淡入协程
    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeInTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);
            SetAlpha(waitingWait, alpha);
            SetAlpha(waitingText, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SetAlpha(waitingWait, 1f);
        SetAlpha(waitingText, 1f);
    }

    // 淡出协程
    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeOutTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutTime);
            SetAlpha(waitingWait, alpha);
            SetAlpha(waitingText, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SetAlpha(waitingWait, 0f);
        SetAlpha(waitingText, 0f);
    }

    // 设置 UI 元素的透明度
    private void SetAlpha(Graphic graphic, float alpha)
    {
        Color color = graphic.color;
        color.a = alpha;
        graphic.color = color;
    }
}