using UnityEngine;

public class QuestItem : Interactable
{
    [SerializeField] private string questItem;
    
    public override void Interact()
    {
        base.Interact();
        
        Inventory.Instance.AddItem(questItem);
        Destroy(gameObject);
    }
}
