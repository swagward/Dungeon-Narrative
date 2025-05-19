using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceNPC : Interactable
{
    public SwordManager sword;
    
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text speakerName;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    
    public override void Interact()
    {
        DialogueManager.Instance.DialogueActive = true;
        base.Interact();
        dialogueBox.SetActive(true);
        speakerName.text = "???";
        speakerText.text = "If given the chance, will you take another’s life to save your own?";
    }

    public void GhostYes()
    {
        DialogueManager.Instance.DialogueActive = false;
        sword.secondSwordEvil = true;
        dialogueBox.SetActive(false);
        Destroy(this.gameObject, 1f);
    }

    public void GhostNo()
    {
        DialogueManager.Instance.DialogueActive = false;
        dialogueBox.SetActive(false);
        Destroy(this.gameObject, 1f);
    }
}