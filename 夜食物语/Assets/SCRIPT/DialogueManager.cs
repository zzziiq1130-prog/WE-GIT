using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    [Header("UI 引用")]
    public TextMeshProUGUI nameText;      // 拖入显示名称的 TextMeshPro
    public TextMeshProUGUI contentText;   // 拖入显示台词的 TextMeshPro
    public GameObject dialoguePanel;      // 拖入整个 Image 对话框底板
    public GameObject optionsPanel;       // 拖入存放 4 个按钮的父物体

    [Header("打字机设置")]
    public float typingSpeed = 0.1f;     // 字跳出的速度

    private Coroutine typingCoroutine;
    private bool isTyping = false;
    private string currentFullText = "";

    // 1. 开始对话的方法
    public void ShowDialogue(string name, string content, bool showOptionsAfter = false)
    {
        dialoguePanel.SetActive(true);
        optionsPanel.SetActive(false);
        nameText.text = name;
        currentFullText = content;

        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeText(content, showOptionsAfter));
    }

    // 2. 打字机协程
    IEnumerator TypeText(string text, bool showOptionsAfter)
    {
        isTyping = true;
        contentText.text = "";
        foreach (char c in text.ToCharArray())
        {
            contentText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;

        if (showOptionsAfter)
        {
            optionsPanel.SetActive(true);
        }
    }

    // 3. 快速跳过打字（点击时直接显示全句）
    public void FinishDisplaying()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            contentText.text = currentFullText;
            isTyping = false;
        }
    }
    // 在现有变量定义处添加
    [Header("按钮文字引用")]
    public TextMeshProUGUI[] buttonTexts; // 请在 Inspector 中依次拖入 4 个按钮下的 Text(TMP)

    // 新增：更新按钮显示内容的方法
    public void UpdateOptions(string[] options)
    {
        for (int i = 0; i < buttonTexts.Length; i++)
        {
            if (i < options.Length)
            {
                buttonTexts[i].text = options[i]; // 修改按钮显示的文字
                buttonTexts[i].transform.parent.gameObject.SetActive(true); // 显示有内容的按钮
            }
            else
            {
                buttonTexts[i].transform.parent.gameObject.SetActive(false); // 隐藏多余的按钮
            }
        }
    }

}