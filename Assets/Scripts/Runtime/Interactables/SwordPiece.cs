using UnityEngine;

public class SwordPiece : Interactable
{
    public GameObject objectToRemove;
    public override void Interact()
    {
        base.Interact();
        Destroy(objectToRemove);
        Inventory.Instance.AddItem(this.gameObject.name);
        Destroy(this.gameObject);
    }
}
