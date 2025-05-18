using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public enum QuestState
    {
        NotStarted,
        Accepted,
        Declined,
        Completed,
    };
    private readonly Dictionary<QuestData, QuestState> _questStates = new(); 

    private void Awake()
    {
        if(Instance is null) 
            Instance = this;
        else 
            Destroy(gameObject);
    }

    public void StartQuest(QuestData quest)
        => _questStates[quest] = QuestState.Accepted;
    
    public void DeclineQuest(QuestData quest)
        => _questStates[quest] = QuestState.Declined;
    
    public void CompleteQuest(QuestData quest)
        => _questStates[quest] = QuestState.Completed;
    
    public QuestState GetState(QuestData quest)
        => _questStates.GetValueOrDefault(quest, QuestState.NotStarted);
    
    public bool HasItem(string itemName)
        => Inventory.Instance.HasItem(itemName);
}
