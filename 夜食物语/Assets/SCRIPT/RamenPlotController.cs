using UnityEngine;

public class RamenPlotController : MonoBehaviour
{
    [Header("系统引用")]
    public DialogueManager dm;
    public PlayerScore playerScore; // 拖入挂载了 PlayerScore 脚本的玩家物体
    public Transform spawnPoint;    // 食物弹出的位置（建议设在小人前方空地）

    [Header("食物预制体")]
    public GameObject ramenPrefab;
    public GameObject burgerPrefab;
    public GameObject dessertPrefab;
    public GameObject octopusPrefab;

    [HideInInspector] public CatType currentTalkingCat; // 记录当前对话的是哪只猫

    // ================== 各店初始剧情（触发对话） ==================

    public void StartRamenStory()
    {
        dm.ShowDialogue("面面", "喵～欢迎光临！我是店员面面～骨汤拉面 10 金币一份，要试试吗？", true);
        dm.UpdateOptions(new string[] { "我要骨汤拉面！(10金币)", "试试豚骨拉面吧～(10金币)", "有不辣的吗？", "可以少做点面吗？" });
    }

    public void StartBurgerStory()
    {
        dm.ShowDialogue("堡堡", "喵呜～我是店员堡堡！招牌芝士牛肉堡 12 金币，想吃吗？", true);
        dm.UpdateOptions(new string[] { "我要芝士牛肉堡！(12金币)", "小鱼干汉堡！(10金币)", "不辣蔬菜堡？", "芝士多吗？" });
    }

    public void StartDessertStory()
    {
        dm.ShowDialogue("糖糖", "喵～我是糖糖～草莓舒芙蕾 8 金币，甜甜的很治愈哦！", true);
        dm.UpdateOptions(new string[] { "草莓舒芙蕾！(8金币)", "热牛奶咖啡～(5金币)", "不甜原味蛋糕？", "是现做的吗？" });
    }

    public void StartOctopusStory()
    {
        dm.ShowDialogue("烧烧", "喵哈！我是烧烧！现烤章鱼烧 6 金币一份，超入味！", true);
        dm.UpdateOptions(new string[] { "原味章鱼烧！(6金币)", "撒海苔碎的！(6金币)", "不加沙拉酱？", "章鱼块大吗？" });
    }

    // ================== 通用购买与弹出逻辑 ==================

    // 内部通用方法：检查钱 -> 扣钱 -> 说话 -> 喷出食物
    private void TryBuyFood(GameObject foodPrefab, string catName, string successWords, int price)
    {
        if (playerScore.SpendCoins(price)) // 调用金币脚本的扣费函数
        {
            // 1. 说话
            dm.ShowDialogue(catName, successWords, false);

            // 2. 弹出食物
            if (foodPrefab != null && spawnPoint != null)
            {
                GameObject food = Instantiate(foodPrefab, spawnPoint.position, Random.rotation);
                Rigidbody rb = food.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // 给食物一个向上和向前的随机力，让它“蹦”出来
                    Vector3 force = (Vector3.up * 5f) + (spawnPoint.forward * 2f);
                    rb.AddForce(force, ForceMode.Impulse);
                }
            }
        }
        else
        {
            // 钱不够时的对话
            dm.ShowDialogue(catName, "哎呀，你的金币好像不够哦喵～快去附近找找金币吧！", false);
        }
    }

    // ================== 按钮点击事件（关联到 UI Button） ==================

    public void OnClickOption1()
    {
        switch (currentTalkingCat)
        {
            case CatType.Ramen: TryBuyFood(ramenPrefab, "面面", "好耶！骨汤拉面一份～溏心蛋要加吗？免费的哦！", 10); break;
            case CatType.Burger: TryBuyFood(burgerPrefab, "堡堡", "好耶！芝士牛肉堡一份！吃了我的汉堡，一定开开心心！", 12); break;
            case CatType.Dessert: TryBuyFood(dessertPrefab, "糖糖", "好呀！草莓舒芙蕾一份～现做的要等一小会儿哦！", 8); break;
            case CatType.Octopus: TryBuyFood(octopusPrefab, "烧烧", "好嘞！原味章鱼烧一份！我多给你淋一点秘制酱汁！", 6); break;
        }
    }

    public void OnClickOption2()
    {
        switch (currentTalkingCat)
        {
            case CatType.Ramen: TryBuyFood(ramenPrefab, "面面", "收到！豚骨拉面一份～味道更醇厚哦！", 10); break;
            case CatType.Burger: TryBuyFood(burgerPrefab, "堡堡", "哇！你选了小鱼干汉堡～我会多放一点小鱼干的～", 10); break;
            case CatType.Dessert: TryBuyFood(dessertPrefab, "糖糖", "收到！热牛奶咖啡一杯～喝起来暖暖的！", 5); break;
            case CatType.Octopus: TryBuyFood(octopusPrefab, "烧烧", "海苔碎都是现磨的，超鲜！拿好啦，小心烫哦！", 6); break;
        }
    }

    // 选项 3 和 4 通常是询问（不花钱），直接显示对话即可
    public void OnClickOption3()
    {
        switch (currentTalkingCat)
        {
            case CatType.Ramen: dm.ShowDialogue("面面", "有的！清汤拉面很清爽，里面有青菜和鸡蛋～", false); break;
            case CatType.Burger: dm.ShowDialogue("堡堡", "有的！我们的蔬菜汉堡一点都不辣，还很清爽～", false); break;
            case CatType.Dessert: dm.ShowDialogue("糖糖", "有的！原味戚风蛋糕就不甜，口感软软的～", false); break;
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