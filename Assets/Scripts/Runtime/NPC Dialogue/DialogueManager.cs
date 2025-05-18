using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public bool DialogueActive { get; private set; }
    
    [Header("UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text speakerName;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private Button continueButton;

    [SerializeField] private float typingSpeed = 0.05f;
    
    private string[] _currentLines;
    private int _currentLineIndex;
    private Coroutine _typingCoroutine;
    private System.Action _onDialogueEnd;

    private void Awake()
    {
        if(Instance is null) Instance = this;
        else Destroy(gameObject);
        
        dialogueBox.SetActive(false);
        continueButton.onClick.AddListener(ContinueDialogue);
    }
    
    public void StartDialogue(string speaker, string[] lines, System.Action onDialogueEnd = null)
    {
        DialogueActive = true;
        dialogueBox.SetActive(true);
        
        speakerName.text = speaker;
        _currentLines = lines;
        _currentLineIndex = 0;
        _onDialogueEnd = onDialogueEnd;

        ShowLine();
    }
    
    private void ShowLine()
    {
        if (_typingCoroutine != null)
            StopCoroutine(_typingCoroutine);

        _typingCoroutine = StartCoroutine(TypeLine(_currentLines[_currentLineIndex]));
    }

    private IEnumerator TypeLine(string line)
    {
        speakerText.text = "";
        continueButton.interactable = false;

        foreach (char c in line)
        {
            speakerText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        continueButton.interactable = true;
    }
    
    private void ContinueDialogue()
    {
        _currentLineIndex++;
        if (_currentLineIndex < _currentLines.Length)
            ShowLine();
        else
            EndDialogue();
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        DialogueActive = false;
        _onDialogueEnd?.Invoke();
    }
}