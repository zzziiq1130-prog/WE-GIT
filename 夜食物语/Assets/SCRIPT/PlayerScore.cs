using UnityEngine;
using TMPro; // 如果你使用 TextMeshPro 显示分数

public class PlayerScore : MonoBehaviour
{
    public int currentScore = 0;
    public TextMeshProUGUI scoreText; // 拖入 UI 上的分数文字组件

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
        Debug.Log("当前金币总数: " + currentScore);
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "金币: " + currentScore;
        }
    }
    public bool SpendCoins(int amount)
    {
        if (currentScore >= amount)
        {
            currentScore -= amount;
            UpdateScoreUI();
            return true; // 钱够，扣费成功
        }
        return false; // 钱不够
    }
}