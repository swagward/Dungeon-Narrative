using UnityEngine;

public class NPC : Interactable
{
    [Header("Dialogue")]
    public DialogueLines dialogue;
    public bool isQuestGiver;
    public string requiredItem;
    public bool objectToAdd;
    public GameObject objectAdded;
    public GameObject objectToRemove;
    public bool npcRemover;
    private bool _questGiven;
    private bool _questCompleted;
    public SwordManager SwordManager;

    public override void Interact()
    {
        if (DialogueManager.Instance.DialogueActive) return;

        if (isQuestGiver)
        {
            if (!_questGiven)
            {
                _questGiven = true;
                DialogueManager.Instance.StartDialogue(dialogue.speakerName, dialogue.lines, OnDialogueFinished);
            }
            else if (!_questCompleted)
            {
                if (Inventory.Instance.HasItem(requiredItem))
                {
                    _questCompleted = true;
                    if (npcRemover) 
                    { 
                        objectToRemove.SetActive(false);
                    }
                    if(requiredItem == "Sword Piece")
                    {
                        SwordManager.firstSwordEvil = true;
                    }
                    if (objectToAdd)
                    {
                        objectAdded.SetActive(true);
                    }
                    Inventory.Instance.RemoveItem(requiredItem);
                    DialogueManager.Instance.StartDialogue(dialogue.speakerName, new[] { "Thanks for bringing it to me!" });
                }
                else DialogueManager.Instance.StartDialogue(dialogue.speakerName, new[] { "Dont talk to me until you bring me my stuff" });
                
            }
        }
        else DialogueManager.Instance.StartDialogue(dialogue.speakerName, dialogue.lines, OnDialogueFinished);
    }

    private void OnDialogueFinished()
    {
        // Only needed if you want to hook something in.
    }
}
