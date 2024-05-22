using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialgoueInteractable : Interactable
{

    [SerializeField] List<string> dialogue;

    [SerializeField] GameObject dialogueObject;
    [SerializeField] TextMeshPro textMesh;

    private int currentLine;

    public override void Interact()
    {
        base.Interact();
    }
}
