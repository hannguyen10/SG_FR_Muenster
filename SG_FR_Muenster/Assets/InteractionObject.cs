using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour, IInteractables
{

    public bool IsActivated { get; private set;}
    public string ObjectID { get; private set;}
    
    void Start()
    {
        ObjectID ??= GlobalHelper.GenerateUniqueID(gameObject); //UniqueID
    }

   


    public bool CanInteract()
    {
        return !IsActivated;
    }

    public void Interact()
    {
        if(!CanInteract()) return;
    }

    
}
