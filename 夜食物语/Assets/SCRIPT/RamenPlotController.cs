using UnityEngine;

public class RamenPlotController : MonoBehaviour
{
    public DialogueManager dm;
    [HideInInspector] public CatType currentTalkingCat; // 记录当前对话者

    // ================== 各店初始剧情 ==================

    public void StartStory()
    { // 面面
        dm.ShowDialogue("面面", "喵～欢迎光临！我是店员面面～我们家有骨汤拉面和豚骨拉面，请问你想吃哪种呀？", true);
        dm.UpdateOptions(new string[] { "我要骨汤拉面！", "试试豚骨拉面吧～", "有不辣的清汤吗？", "可以少做点面吗？" });
    }

    public void StartBurgerStory()
    { // 堡堡
        dm.ShowDialogue("堡堡", "喵呜～可以呀！我是这里的店员堡堡！请问你想吃什么汉堡呀？", true);
        dm.UpdateOptions(new string[] { "我要芝士牛肉堡！", "小鱼干汉堡！", "不辣蔬菜堡？", "芝士多吗？" });
    }

    public void StartDessertStory()
    { // 糖糖
        dm.ShowDialogue("糖糖", "喵～欢迎光临！我是店员糖糖～我们家有蛋糕和咖啡，想吃什么呀？", true);
        dm.UpdateOptions(new string[] { "我要草莓舒芙蕾！", "热牛奶咖啡～", "原味戚风蛋糕？", "是现做的吗？" });
    }

    public void StartOctopusStory()
    { // 烧烧
        dm.ShowDialogue("烧烧", "喵哈！欢迎光临～我是店员烧烧！我们家的章鱼烧都是现烤的，超入味！", true);
        dm.UpdateOptions(new string[] { "我要原味章鱼烧！", "撒海苔碎的！", "不加沙拉酱？", "章鱼块大吗？" });
    }

    // ================== 通用按钮点击逻辑 ==================

    public void OnClickOption1()
    {
        switch (currentTalkingCat)
        {
            case CatType.Ramen: dm.ShowDialogue("面面", "好耶！骨汤拉面一份～溏心蛋要加吗？免费的哦！", false); break;
            case CatType.Burger: dm.ShowDialogue("堡堡", "好耶！芝士牛肉堡一份！吃了我的汉堡，一定会开开心心的！", false); break;
            case CatType.Dessert: dm.ShowDialogue("糖糖", "好呀！草莓舒芙蕾一份～现做的要等一小会儿哦！", false); break;
            case CatType.Octopus: dm.ShowDialogue("烧烧", "好嘞！原味章鱼烧一份！我多给你淋一点秘制酱汁！", false); break;
        }
    }

    public void OnClickOption2()
    {
        switch (currentTalkingCat)
        {
            case CatType.Ramen: dm.ShowDialogue("面面", "收到！豚骨拉面一份～味道更醇厚哦！马上煮面，小爪子超麻利的！", false); break;
            case CatType.Burger: dm.ShowDialogue("堡堡", "哇！你居然选了小鱼干汉堡～我会多放一点小鱼干的～", false); break;
            case CatType.Dessert: dm.ShowDialogue("糖糖", "收到！热牛奶咖啡一杯～我会多放牛奶，喝起来暖暖的！", false); break;
            case CatType.Octopus: dm.ShowDialogue("烧烧", "哇！海苔爱好者同款！海苔碎都是现磨的，超鲜！", false); break;
        }
    }

    public void OnClickOption3()
    {
        switch (currentTalkingCat)
        {
            case CatType.Ramen: dm.ShowDialogue("面面", "有的！清汤拉面很清爽，里面有青菜和鸡蛋～马上煮！", false); break;
            case CatType.Burger: dm.ShowDialogue("堡堡", "有的有的！我们的蔬菜汉堡一点都不辣，还很清爽～", false); break;
            case CatType.Dessert: dm.ShowDialogue("糖糖", "有的有的！原味戚风蛋糕就不甜，口感软软的～需要帮你切一块吗？", false); break;
            case CatType.Octopus: dm.ShowDialogue("烧烧", "可以的！只淋酱汁不撒沙拉酱～原味马上好！", false); break;
        }
    }

    public void OnClickOption4()
    {
        switch (currentTalkingCat)
        {
            case CatType.Ramen: dm.ShowDialogue("面面", "可以的！少面没问题～我这就去准备！", false); break;
            case CatType.Burger: dm.ShowDialogue("堡堡", "多的多的！如果芝士不够的话，还可以免费加一份哦～", false); break;
            case CatType.Dessert: dm.ShowDialogue("糖糖", "是的！现做的才松软好吃～不过要等5分钟左右哦！", false); break;
            case CatType.Octopus: dm.ShowDialogue("烧烧", "超大的！你看～每颗里面都有一块完整的章鱼！", false); break;
        }
    }
}