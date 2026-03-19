using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace NaughtyWaterBuoyancy
{
    public class TEXTpop : MonoBehaviour
    {
        public Image Image; // 成就提示框的 Image 组件
        public Text Text;   // 成就提示框的 Text 组件
        public float Time1 = 0.5f; // 淡入时间
        public float Time2 = 1f;  // 淡出时间
        public float Time3 = 2f;  // 显示时间

        public KeyCode[] triggerKeys; // 可在Inspector面板配置的触发按键
        [TextArea(3, 10)] // 使用 TextArea 属性，3 为最小行数，10 为最大行数
        public string achievementMessage = "1"; // 可在Inspector面板配置的成就消息
        private Coroutine Coroutine;
        public int requiredPressCount = 2; // 可在Inspector面板配置的所需按键按下次数
        private int pressCount = 0; // 记录按键按下的次数

        private bool Shown = false; // 记录成就是否已显示
        void Start()
        {
            // 设置文本的对齐方式为左上对齐，以更好地显示多行文本
            Text.alignment = TextAnchor.UpperLeft;
        }
        void Update()
        {
            if (Shown) return;

            foreach (KeyCode key in triggerKeys)
            {
                if (Input.GetKeyDown(key))
                {
                    pressCount++;
                    if (pressCount >= requiredPressCount)
                    {
                        Popup(achievementMessage);
                        Shown = true; // 标记成就已显示
                        pressCount = 0; // 重置计数
                        break;
                    }
                }
            }
        }

        public void Popup(string achievementMessage)
        {
            if (Coroutine != null)
            {
                StopCoroutine(Coroutine);
            }

            Text.text = achievementMessage;
            Coroutine = StartCoroutine(Fade());
        }

        private IEnumerator Fade()
        {
            // 淡入
            float elapsedTime = 0f;
            Color startColor = Image.color;
            startColor.a = 0f;
            Color endColor = startColor;
            endColor.a = 1f;

            while (elapsedTime < Time1)
            {
                Image.color = Color.Lerp(startColor, endColor, elapsedTime / Time1);
                Text.color = Color.Lerp(startColor, endColor, elapsedTime / Time1);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            Image.color = endColor;
            Text.color = endColor;

            // 显示一段时间
            yield return new WaitForSeconds(Time3);

            // 淡出
            elapsedTime = 0f;
            startColor = endColor;
            endColor.a = 0f;

            while (elapsedTime < Time2)
            {
                Image.color = Color.Lerp(startColor, endColor, elapsedTime / Time2);
                Text.color = Color.Lerp(startColor, endColor, elapsedTime / Time2);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            Image.color = endColor;
            Text.color = endColor;
        }
    }
}