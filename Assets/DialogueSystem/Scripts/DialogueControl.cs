using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControl : MonoBehaviour
{
    private StarterAssetsInputs Inputs;
    private bool DialogueSystem;
    private bool StartDialogue;



    void Start()
    {
        Inputs = GetComponent<StarterAssetsInputs>();
        DialogueSystem = false;
        StartDialogue = true;
    }

    private void Update()
    {
        if (DialogueSystem)
        {
            if (Inputs.action)
            {
                if (StartDialogue)
                    FindObjectOfType<DialogueManager>().DisplayNextSentence();
                Inputs.action = false;
            }
        }
    }

    public void DialogueSystemOn()
    {
        DialogueSystem = true;
    }
    public void DialogueSystemOff()
    {
        DialogueSystem = false;
    }
}
