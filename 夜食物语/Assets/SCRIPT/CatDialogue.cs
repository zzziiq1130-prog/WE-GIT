using UnityEngine;

// 定义四只猫的类型
public enum CatType { Ramen, Burger, Dessert, Octopus }

public class CatDialogue : MonoBehaviour
{
    public CatType currentCat; // 在 Inspector 面板下拉选择这只猫的身份
    public DialogueManager dialogueManager;
    public RamenPlotController plotController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 告诉控制器当前对话的小猫是谁
            plotController.currentTalkingCat = currentCat;

            // 根据身份启动初始剧情
            switch (currentCat)
            {
                case CatType.Ramen: plotController.StartStory(); break;
                case CatType.Burger: plotController.StartBurgerStory(); break;
                case CatType.Dessert: plotController.StartDessertStory(); break;
                case CatType.Octopus: plotController.StartOctopusStory(); break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.GetComponent<CharacterController>() != null)
        {
            dialogueManager.dialoguePanel.SetActive(false);
            dialogueManager.optionsPanel.SetActive(false);
        }
    }
}