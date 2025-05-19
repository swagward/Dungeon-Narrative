using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalSword : Interactable
{
    public SwordManager sword;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text speakerName;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    public GameObject EvilEnding;
    public GameObject goodEnding;
    public GameObject neutralEnding;

    public override void Interact()
    {
        if(sword.firstSwordEvil && sword.secondSwordEvil)
        {
            EvilEnding.SetActive(true);
        }
        else
        {
            DialogueManager.Instance.DialogueActive = true;
            base.Interact();
            dialogueBox.SetActive(true);
            speakerName.text = "???";
            speakerText.text = "Do you wish to keep the sword, or seal it away with yourself?";
        }
    }

    public void Keep()
    {
        DialogueManager.Instance.DialogueActive = false;
        neutralEnding.SetActive(true);
    }

    public void Seal()
    {
        DialogueManager.Instance.DialogueActive = false;
        dialogueBox.SetActive(false);
        goodEnding.SetActive(true);
    }
}
