using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSpeaker : Interactable
{
    public static bool DialogueActive { get; private set; }
    
    [Header("NPC Dialogue")]
    [SerializeField] private DialogueLines lines;
    [SerializeField] private float typeSpeed;
    
    [Header("UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text speakerNameText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button continueButton;
    
    private Coroutine _typewriterEffect;
    private int _currentIndex;

    private void Start()
    {
        dialoguePanel.SetActive(false);
        continueButton.onClick.AddListener(NextLine);
    }

    public override void Interact()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        _currentIndex = 0;
        if (lines != null && lines.dialogue.Length > 0)
        {
            DialogueActive = true;
            dialoguePanel.SetActive(true);
            speakerNameText.text = lines.speakerName;
            ShowLine();
        }
    }

    private void ShowLine()
    {
        if(_typewriterEffect is not null)
            StopCoroutine(_typewriterEffect);
        
        if (_currentIndex < lines.dialogue.Length)
            _typewriterEffect = StartCoroutine(TypeLine(lines.dialogue[_currentIndex]));
        else EndDialogue();
    }

    private IEnumerator TypeLine(string dialogueLine)
    {
        dialogueText.text = "";
        continueButton.interactable = false;

        foreach (var c in dialogueLine.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
        
        continueButton.interactable = true;
    }

    private void NextLine()
    {
        _currentIndex++;
        ShowLine();
    }

    private void EndDialogue()
    {
        DialogueActive = false;
        dialoguePanel.SetActive(false);
    }
}