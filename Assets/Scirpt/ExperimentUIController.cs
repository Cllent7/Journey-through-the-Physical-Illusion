using UnityEngine;
using UnityEngine.UI;

public class ExperimentUIController : MonoBehaviour
{
    public Button btnStart;
    public Text txtResult;
    public Slider heavyAirResistanceSlider; // 重球空气阻力滑块
    public Slider lightAirResistanceSlider; // 轻球空气阻力滑块
    public ExperimentManager experimentManager;

    private float increaseRate = 0.1f;
    private float lastIncreaseTime;
    private float increaseInterval = 0.1f; // 按键长按增加的频率

    void Start()
    {
        // 绑定Slider值改变事件
        btnStart.onClick.AddListener(experimentManager.StartExperiment);
        heavyAirResistanceSlider.onValueChanged.AddListener(SetHeavyAirResistance);
        lightAirResistanceSlider.onValueChanged.AddListener(SetLightAirResistance);
    }

    void Update()
    {
        // 处理空格键按下事件
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (btnStart != null)
            {
                btnStart.onClick.Invoke();
            }
            else
            {
                Debug.LogError("btnStart 未赋值，请在 Inspector 面板中赋值。");
            }
        }

        // 处理 Q 键和 Shift + Q 键事件
        HandleKeyInput(KeyCode.Q, heavyAirResistanceSlider, Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));

        // 处理 R 键和 Shift + E 键事件
        HandleKeyInput(KeyCode.R, lightAirResistanceSlider, Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
    }

    void HandleKeyInput(KeyCode key, Slider slider, bool isDecreasing)
    {
        if (Input.GetKeyDown(key) || (Input.GetKey(key) && Time.time - lastIncreaseTime >= increaseInterval))
        {
            float change = isDecreasing ? -increaseRate : increaseRate;
            float newValue = slider.value + change;
            newValue = Mathf.Clamp(newValue, 0f, 1f);
            if (newValue != slider.value)
            {
                slider.value = newValue;
                lastIncreaseTime = Time.time;
            }
        }
    }

    // 设置重球的空气阻力
    private void SetHeavyAirResistance(float value)
    {
        experimentManager.heavyObject.SetAirResistance(value);
    }

    // 设置轻球的空气阻力
    private void SetLightAirResistance(float value)
    {
        experimentManager.lightObject.SetAirResistance(value);
    }

    /// <summary>
    /// 显示实验结果
    /// </summary>
    /// <param name="heavyTime">重物下落时间</param>
    /// <param name="lightTime">轻物下落时间</param>
    /// <param name="theoryTime">理论计算时间</param>
    public void ShowResult(float heavyTime, float lightTime, float theoryTime)
    {
        // 构建报告字符串
        string report = $"理论Time：{theoryTime:F2}s\n" +
                        $"重物Time：{heavyTime:F2}s\n" +
                        $"轻物Time：{lightTime:F2}s\n" +
                        $"结论：{(Mathf.Abs(heavyTime - lightTime) < 0.01f ? "验证成功" : "验证失败")}";

        // 更新UI文本
        txtResult.text = report;
    }
}
