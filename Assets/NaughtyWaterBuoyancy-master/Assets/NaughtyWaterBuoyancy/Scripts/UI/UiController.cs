using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NaughtyWaterBuoyancy
{
    public class FloatingObjectUI : MonoBehaviour
    {
        public Image colorImage;
        public Text densityText;
        public GameObject[] dynamicObjects;
        public Material[] buoyancyMaterials;

        private int selectedObjectIndex = 0;

        void Start()
        {
            UpdateUI();
        }

        void Update()
        {
            // 选择对象
            for (int i = 1; i <= 6; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha0 + i))
                {
                    selectedObjectIndex = i - 1;
                    if (IsValidIndex(selectedObjectIndex))
                    {
                        UpdateUI();
                    }
                }
            }

            // 按下Q和E键
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (IsValidIndex(selectedObjectIndex))
                {
                    DecreaseDensity();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (IsValidIndex(selectedObjectIndex))
                {
                    IncreaseDensity();
                }
            }
        }

        bool IsValidIndex(int index)
        {
            return index >= 0 && index < dynamicObjects.Length && dynamicObjects[index] != null;
        }

        void UpdateUI()
        {
            if (IsValidIndex(selectedObjectIndex))
            {
                // 更新颜色
                colorImage.color = buoyancyMaterials[selectedObjectIndex].color;

                // 更新密度文本
                FloatingObject floatingObject = dynamicObjects[selectedObjectIndex].GetComponent<FloatingObject>();
                if (floatingObject != null)
                {
                    densityText.text = "密度: " + floatingObject.density.ToString("F1");
                }
               
            }
        }

        void DecreaseDensity()
        {
            FloatingObject floatingObject = dynamicObjects[selectedObjectIndex].GetComponent<FloatingObject>();
            if (floatingObject != null)
            {
                // 检查当前密度是否大于要减少的量
                if (floatingObject.density > 0.1f)
                {
                    floatingObject.DecreaseDensity(0.1f);
                    UpdateUI();
                }
            }
        }

        void IncreaseDensity()
        {
            FloatingObject floatingObject = dynamicObjects[selectedObjectIndex].GetComponent<FloatingObject>();
            if (floatingObject != null)
            {
                floatingObject.IncreaseDensity(0.1f);
                UpdateUI();
            }
        }

    }
}