using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGenerator : MonoBehaviour, IInteractable
{
    private Renderer rend;
    private Color originalColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void Interact()
    {
        Debug.Log(Random.Range(0, 100));
    }

    public void OnHoverEnter()
    {
        rend.material.color = Color.yellow; // Leuchten
    }

    public void OnHoverExit()
    {
        rend.material.color = originalColor; // Zurücksetzen
    }
}
