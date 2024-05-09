using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class VictimTalk2 : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger;
    private bool isInsideTrigger;
    public GameObject TalkPanel, PlayerCapsule, Camera;
    public TMP_Text TalkText;
    private string[] dialogues = { "", "The one thing they dont know yet is what weapon was used for my murder.", "I was pretty mouldy by the time they found me... it's undetermined", "So in this section, where my murderer was last spotted, I need you to look around for it.", "When you see me again I'll have new instructions for you, so make sure you find what you need.", "Make sure to remember your findings, you'll have to test your knowledge in the case file later.", "And a tip, criminals are misleading, make sure you are both looking for clues and speaking to passerbys.", "Best of luck, I'll see you soon!" };

    
    void Start()
    {
        TalkPanel.SetActive(false);
        Camera.SetActive(false);
        PlayerCapsule.SetActive(true);
    }

   
    void Update()
    {
        if (isInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
            StartCoroutine(DisplayDialogues());
        }
    }

    IEnumerator DisplayDialogues()
    {
        for (int i = 0; i < dialogues.Length; i++)
        {
            Debug.Log("Displaying dialogue: " + dialogues[i]); 
            TalkText.text = dialogues[i];
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E)); 
            yield return null; 
        }

        EndDialogue();
    }


    void EndDialogue()
    {
        TalkPanel.SetActive(false);
        Camera.SetActive(false);
        PlayerCapsule.SetActive(true);
    }

    void StartDialogue()
    {
        TalkPanel.SetActive(true);
        Camera.SetActive(true);
        PlayerCapsule.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enteredTrigger.Invoke();
            isInsideTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            exitedTrigger.Invoke();
            isInsideTrigger = false;
        }
    }
}
