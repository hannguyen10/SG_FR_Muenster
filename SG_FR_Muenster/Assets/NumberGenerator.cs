using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGenerator : MonoBehaviour, IInteractable
{
    private Renderer rend;
    private Material mat;

    private Color baseEmission = Color.black;
    private Color glowEmission = Color.yellow * 2f; // Intensität!

    void Start()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material; // eigene Instanz!
        mat.EnableKeyword("_EMISSION");
    }

    public void OnHoverEnter()
    {
        mat.SetColor("_EmissionColor", glowEmission);
    }

    public void OnHoverExit()
    {
        mat.SetColor("_EmissionColor", baseEmission);
    }

    public void Interact()
    {
        Debug.Log(Random.Range(0, 100));
    }
}
