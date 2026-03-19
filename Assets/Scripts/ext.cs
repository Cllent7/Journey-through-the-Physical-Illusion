using UnityEngine;

public class ext : MonoBehaviour
{
    // 退出游戏的方法
    void Update()
    {
        // 检测是否按下了 Esc 键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    // 退出游戏的方法
    public void QuitGame()
    {
#if UNITY_EDITOR
        // 在 Unity 编辑器中，使用 UnityEditor.EditorApplication.isPlaying 来停止播放
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 在发布的游戏中，使用 Application.Quit 来退出游戏
        Application.Quit();
#endif
    }
}