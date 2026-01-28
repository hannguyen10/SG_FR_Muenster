using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public MouseMovement mouseMovement;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private bool dialogueActive = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueActive) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        Debug.Log("Dialog startet");

        index = 0;
        dialogueActive = true;

        if (mouseMovement != null)
        {
            mouseMovement.lookEnabled = false;
        }
        else
        {
            Debug.LogError("MouseMovement ist NICHT zugewiesen!");
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueActive = false;

            mouseMovement.lookEnabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            gameObject.SetActive(false);
        }
    }
}