using UnityEngine;

interface IInteractable
{
    void Interact();

    void OnHoverEnter();
    void OnHoverExit();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange = 3f;

    private IInteractable currentInteractable;

    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);

        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.TryGetComponent(out IInteractable interactable))
            {
                // Neues Objekt angeschaut
                if (currentInteractable != interactable)
                {
                    currentInteractable?.OnHoverExit();
                    currentInteractable = interactable;
                    currentInteractable.OnHoverEnter();
                }
                return;
            }
        }

        // Wenn nichts mehr angeschaut wird
        if (currentInteractable != null)
        {
            currentInteractable.OnHoverExit();
            currentInteractable = null;
        }
    }
}
