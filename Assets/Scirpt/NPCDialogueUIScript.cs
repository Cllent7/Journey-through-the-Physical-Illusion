using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPCDialogueUIScript : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E; // 与 NPC 交互的按键，可在 Inspector 面板修改
    public Text dialoguePromptText; // 用于显示提示信息的 Text 组件
    public float fadeInTime = 1f; // 淡入时间
    public float fadeOutTime = 1f; // 淡出时间
    public float displayTime = 3f; // 显示时长

    void Start()
    {
        // 检查 Text 组件是否已赋值
        if (dialoguePromptText != null)
        {
            // 设置提示文本内容
            dialoguePromptText.text = $"靠近 阿古 按 {interactionKey} 与 他 对话";
            // 初始时文本透明度为 0
            Color textColor = dialoguePromptText.color;
            textColor.a = 0f;
            dialoguePromptText.color = textColor;
            // 启动淡入淡出协程
            StartCoroutine(FadeInAndOut());
        }
        else
        {
            Debug.LogError("dialoguePromptText 未赋值，请在 Inspector 面板中赋值。");
        }
    }

    public IEnumerator FadeInAndOut()
    {
        // 淡入
        float elapsedTime = 0f;
        Color startColor = dialoguePromptText.color;
        startColor.a = 0f;
        Color endColor = startColor;
        endColor.a = 1f;

        while (elapsedTime < fadeInTime)
        {
            dialoguePromptText.color = Color.Lerp(startColor, endColor, elapsedTime / fadeInTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        dialoguePromptText.color = endColor;

        // 显示一段时间
        yield return new WaitForSeconds(displayTime);

        // 淡出
        elapsedTime = 0f;
        startColor = endColor;
        endColor.a = 0f;

        while (elapsedTime < fadeOutTime)
        {
            dialoguePromptText.color = Color.Lerp(startColor, endColor, elapsedTime / fadeOutTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        dialoguePromptText.color = endColor;
    }
}