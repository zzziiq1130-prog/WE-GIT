using UnityEngine;

public class RamenPlotController : MonoBehaviour
{
    public DialogueManager dm; // 拖入 GameManager

    // 第一步：玩家靠近，面面打招呼
    public void StartStory()
    {
        dm.ShowDialogue("面面", "喵～欢迎光临！我是店员面面～我们家有骨汤拉面和豚骨拉面，请问你想吃哪种呀？", false);
        // 这里可以配合点击屏幕继续的功能，为了简单，我们直接进入推荐环节
        Invoke("RecommendRamen", 3f);
    }

    // 第二步：面面推荐
    void RecommendRamen()
    {
        dm.ShowDialogue("面面", "推荐骨汤拉面！汤底熬了好久，超浓郁的～还有溏心蛋和叉烧，分量很足哦！", false);
        Invoke("AskForChoice", 3f);
    }

    // 第三步：询问并显示选项
    void AskForChoice()
    {
        dm.ShowDialogue("面面", "冬天吃一碗超舒服的！你决定好要吃什么了吗？选一个我马上帮你煮面！", true);

        // 【关键】动态改变按钮上的文字
        string[] ramenChoices = {
            "我要骨汤拉面！",
            "试试豚骨拉面吧～",
            "有不辣的清汤吗？",
            "可以少做点面吗？"
        };
        dm.UpdateOptions(ramenChoices);
    }

    // --- 以下为四个选项点击后的分支 ---

    public void OnSelectOption1() // 对应“我要骨汤拉面！”
    {
        dm.ShowDialogue("面面", "好耶！骨汤拉面一份～溏心蛋要加吗？免费的哦！马上就好～", false);
    }

    public void OnSelectOption2() // 对应“试试豚骨拉面吧～”
    {
        dm.ShowDialogue("面面", "收到！豚骨拉面一份～味道更醇厚哦！马上煮面，小爪子超麻利的！", false);
    }

    public void OnSelectOption3() // 对应“有不辣的清汤吗？”
    {
        dm.ShowDialogue("面面", "有的！清汤拉面很清爽，有青菜和鸡蛋～马上煮，很快就好！", false);
    }

    public void OnSelectOption4() // 对应“可以少做点面吗？”
    {
        dm.ShowDialogue("面面", "可以的！少面没问题～我这就去准备！", false);
    }
}