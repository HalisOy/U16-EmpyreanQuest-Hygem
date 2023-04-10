using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private TextMeshProUGUI DialogueText;

    [SerializeField] private Animator Anim;
    [SerializeField] private Animator AnimButton;

    [SerializeField] private Queue<string> sentences;

    public bool EndsDialogue;

    void Start()
    {
        sentences = new Queue<string>();
        EndsDialogue = true;
    }

    public void StartDialogue (Dialogue dialogue)
    {
        EndsDialogue = false;
        NameText.text = dialogue.Name;
        Anim.SetBool("IsOpen", true);
        AnimButton.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count==0)
        {
            EndDialogue();
            FindObjectOfType<DialogueControl>().DialogueSystemOff();
            FindObjectOfType<Mission>().YeniGorevAl();
            return;
        }
        string sentence = sentences.Dequeue();
        DialogueText.text = sentence;
    }

    private void EndDialogue()
    {
        Anim.SetBool("IsOpen", false);
        AnimButton.SetBool("IsOpen", false);
        EndsDialogue = true;
    }
}
