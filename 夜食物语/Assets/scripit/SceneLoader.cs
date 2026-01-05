using UnityEngine;
using UnityEngine.SceneManagement; // 必须引用此命名空间

public class SceneLoader : MonoBehaviour
{
    // 定义一个公共函数，方便在编辑器中调用
    public void LoadGameScene(string sceneName)
    {
        // 按照场景名称加载场景
        SceneManager.LoadScene(sceneName);
    }
}