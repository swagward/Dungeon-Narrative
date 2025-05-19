using UnityEngine;
using UnityEngine.AI;

public class Door : Interactable
{
    public AudioSource openSFX;
    
    public override void Interact()
    {
        base.Interact();
        openSFX.Play();
        Destroy(this.gameObject, .75f);
    }
}