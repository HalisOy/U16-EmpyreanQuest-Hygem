using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool EndDialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>())
        {
            TriggerDialogue();
            other.GetComponent<DialogueControl>().DialogueSystemOn();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>())
        {
            if (EndDialogue)
                other.GetComponent<DialogueControl>().DialogueSystemOff();
        }
    }
}
