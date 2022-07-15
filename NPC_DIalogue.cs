using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_DIalogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;
    
    public DialogueSettings dialogue;

    public bool playerHit;

    private List<string> senteces = new List<string>();

    private void Start()
    {
        GetNPCInfo();
    }

    // é chamado a cada frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.instance.Speech(senteces.ToArray());
        }
    }

    void GetNPCInfo()
    {
        for(int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.language)
            {
                case DialogueControl.idiom.pt:
                    senteces.Add(dialogue.dialogues[i].senteces.portuguese);
                    break;
                case DialogueControl.idiom.eng:
                    senteces.Add(dialogue.dialogues[i].senteces.english);
                    break;
                case DialogueControl.idiom.spa:
                    senteces.Add(dialogue.dialogues[i].senteces.spanish);
                    break;
            }
        }
    }

    //é usado pela fisica
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
