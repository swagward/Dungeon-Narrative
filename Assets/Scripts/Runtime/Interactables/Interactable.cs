using UnityEngine;

public class Interactable : MonoBehaviour
{
    //All interactable objects inherit from this.
    public virtual void Interact()
    {
        Debug.Log("Base interactable");
    }
}
