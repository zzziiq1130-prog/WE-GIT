using UnityEngine;

public class CatDialogue : MonoBehaviour
{
    public GameObject fixedDialogueUI; // 你图里的第一个槽位
    public DialogueManager dialogueManager; // 你图里的第二个槽位

    public RamenPlotController plotController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            plotController.StartStory();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.GetComponent<CharacterController>() != null)
        {
            // 离开时通过面板直接关闭
            dialogueManager.dialoguePanel.SetActive(false);
            dialogueManager.optionsPanel.SetActive(false);
        }
    }
}