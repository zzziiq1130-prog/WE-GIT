using UnityEngine;

public class RamenPlotController : MonoBehaviour
{
    public DialogueManager dm;

    // 触发剧情的起点
    public void StartRamenPlot()
    {
        dm.ShowDialogue("我", "请问这里可以吃拉面吗？");
    }

    // 点击屏幕或按钮继续下一句
    public void Step2()
    {
        dm.ShowDialogue("面面", "喵～欢迎光临！我是店员面面～请问你想吃哪种呀？", true);
        // 这里的 true 表示显示选项面板
    }

    // 选项1的点击事件
    public void OnSelectOption1()
    {
        dm.ShowDialogue("我", "我要骨汤拉面！");
        Invoke("Option1_Response", 2f); // 2秒后执行面面的回应
    }

    void Option1_Response()
    {
        dm.ShowDialogue("面面", "好耶！骨汤拉面一份～溏心蛋要加吗？免费的哦！");
    }
}