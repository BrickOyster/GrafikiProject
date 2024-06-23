using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TextMeshProUGUI Name;

    public Image Thumbnail;
    public TextMeshProUGUI Sentence;

    public Animator _animator;

    // Start is called before the first frame update
    public void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Z))
            DisplayNextSentence();
    }

    public void StartDialogue(Dialogue d)
    {
        sentences.Clear();

        foreach (string sentence in d.sentences)
            sentences.Enqueue(sentence);

        Name.SetText(d.Name);
        if(d.Image)
            Thumbnail.overrideSprite = d.Image;

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        Sentence.SetText(sentence);

        _animator.SetBool("IsOpen",true);
    }

    void EndDialogue()
    {
        _animator.SetBool("IsOpen",false);
    }
}
