using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGargoyleialogue", menuName = "Gargoyle Dialogue")]

public class GargoyleDialogue : ScriptableObject
{
    public string gargoyleName;
    public Sprite portrait;
    public string[] dialogueLines;
    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;
}
