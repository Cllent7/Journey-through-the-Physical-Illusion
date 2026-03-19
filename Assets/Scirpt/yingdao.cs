using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yingdao : NPCDialogueUIScript
{
    // Start is called before the first frame update
    
    new void Start()
    {
        // 检查 Text 组件是否已赋值
        if (dialoguePromptText != null)
        {
            // 修改提示文本内容
            dialoguePromptText.text = $"按 {interactionKey} 往前进入 博物馆";
            // 初始时文本透明度为 0
            Color textColor = dialoguePromptText.color;
            textColor.a = 0f;
            dialoguePromptText.color = textColor;
            // 启动淡入淡出协程
            StartCoroutine(FadeInAndOut());
        }
       
    }
}
