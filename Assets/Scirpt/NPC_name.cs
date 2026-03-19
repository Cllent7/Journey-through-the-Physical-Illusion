using UnityEngine;
using TMPro;

public class NPC_name : MonoBehaviour
{
    public Transform targetCharacter; // 目标相机，通常是主相机
    private TextMeshProUGUI nameText;


    private void Start()
    {
        // 获取 TextMeshProUGUI 组件
        nameText = GetComponent<TextMeshProUGUI>();

        // 检查目标人物是否为空
        if (targetCharacter == null)
        {
            Debug.LogError("未指定目标人物，请在 Inspector 面板中设置 targetCharacter。");
        }
    }

    private void Update()
    {
        if (nameText != null && targetCharacter != null)
        {
            // 让名字始终朝向目标人物
            transform.LookAt(targetCharacter);

            // 修正旋转，确保文字显示正常
            transform.rotation = Quaternion.LookRotation(targetCharacter.position - transform.position);
        }
    }
}