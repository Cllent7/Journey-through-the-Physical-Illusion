using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace NaughtyWaterBuoyancy
{
    public class AchievementPopup : MonoBehaviour
    {
        public Image achievementImage; // 成就提示框的 Image 组件
        public Text achievementText;   // 成就提示框的 Text 组件
        public float fadeInTime = 0.5f; // 淡入时间
        public float fadeOutTime = 1f;  // 淡出时间
        public float displayTime = 2f;  // 显示时间

        public KeyCode[] triggerKeys; // 可在Inspector面板配置的触发按键
        [TextArea(3, 10)] // 使用 TextArea 属性，3 为最小行数，10 为最大行数
        public string achievementMessage = "1"; // 可在Inspector面板配置的成就消息
        private Coroutine currentFadeCoroutine;
        private bool achievementShown = false; // 记录成就是否已显示
        public int requiredPressCount = 2; // 可在Inspector面板配置的所需按键按下次数
        private int pressCount = 0; // 记录按键按下的次数

        void Update()
        {
            if (achievementShown) return;

            foreach (KeyCode key in triggerKeys)
            {
                if (Input.GetKeyDown(key))
                {
                    pressCount++;
                    if (pressCount >= requiredPressCount)
                    {
                        ShowAchievementPopup(achievementMessage);
                        achievementShown = true; // 标记成就已显示
                        pressCount = 0; // 重置计数
                        break;
                    }
                }
            }
        }

        public void ShowAchievementPopup(string achievementMessage)
        {
            if (currentFadeCoroutine != null)
            {
                StopCoroutine(currentFadeCoroutine);
            }

            achievementText.text = achievementMessage;
            currentFadeCoroutine = StartCoroutine(FadeInAndOut());
        }

        private IEnumerator FadeInAndOut()
        {
            // 淡入
            float elapsedTime = 0f;
            Color startColor = achievementImage.color;
            startColor.a = 0f;
            Color endColor = startColor;
            endColor.a = 1f;

            while (elapsedTime < fadeInTime)
            {
                achievementImage.color = Color.Lerp(startColor, endColor, elapsedTime / fadeInTime);
                achievementText.color = Color.Lerp(startColor, endColor, elapsedTime / fadeInTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            achievementImage.color = endColor;
            achievementText.color = endColor;

            // 显示一段时间
            yield return new WaitForSeconds(displayTime);

            // 淡出
            elapsedTime = 0f;
            startColor = endColor;
            endColor.a = 0f;

            while (elapsedTime < fadeOutTime)
            {
                achievementImage.color = Color.Lerp(startColor, endColor, elapsedTime / fadeOutTime);
                achievementText.color = Color.Lerp(startColor, endColor, elapsedTime / fadeOutTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            achievementImage.color = endColor;
            achievementText.color = endColor;
        }
    }
}