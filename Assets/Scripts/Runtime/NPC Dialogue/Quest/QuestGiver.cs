using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private QuestData quest;

    public void Interact()
    {
        var state = QuestManager.Instance.GetState(quest);

        switch (state)
        {
            case QuestManager.QuestState.NotStarted:
                OfferQuest();
                break;
            case QuestManager.QuestState.Accepted:
                CheckCompletion();
                break;
            case QuestManager.QuestState.Declined:
                Debug.Log("This NPC won't talk to you anymore.");
                break;
            case QuestManager.QuestState.Completed:
                Debug.Log("Thanks again!");
                break;
        }
    }
    
    private void OfferQuest()
    {

    }

    private void CheckCompletion()
    {

    }
}
