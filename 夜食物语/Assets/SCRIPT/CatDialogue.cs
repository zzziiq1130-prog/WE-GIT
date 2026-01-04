using UnityEngine;

public class CatDialogue : MonoBehaviour
{
    // 拖入你 Canvas 里的那个固定位置的 Image 物体
    public GameObject fixedDialogueUI;

    private void OnTriggerEnter(Collider other)
    {
        // 当玩家靠近猫咪
        if (other.CompareTag("Player") || other.GetComponent<CharacterController>() != null)
        {
            fixedDialogueUI.SetActive(true); // 激活屏幕上的固定对话框
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 当玩家离开猫咪
        if (other.CompareTag("Player") || other.GetComponent<CharacterController>() != null)
        {
            fixedDialogueUI.SetActive(false); // 隐藏对话框
        }
    }
}