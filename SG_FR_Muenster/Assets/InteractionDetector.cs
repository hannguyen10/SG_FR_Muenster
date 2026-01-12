using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    private IInteractables interactableInRange = null;
    public GameObject interactionSignal;

    
    void Start()
    {
        interactionSignal.SetActive(false);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactableInRange?.Interact();
        }
    }

    private void OnTriggerEnter (Collider collision)
    {
        if(collision.TryGetComponent(out IInteractables interactables) && interactables.CanInteract()) {
            interactableInRange = interactables;
            interactionSignal.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.TryGetComponent(out IInteractables interactables) && interactables == interactableInRange) {
            interactableInRange = null;
            interactionSignal.SetActive(false);
        }
    }
}
