using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class VictimTalk6 : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger;
    private bool isInsideTrigger;
    public GameObject TalkPanel, PlayerCapsule, Camera, LockedBook;
    public TMP_Text TalkText;
    private string[] dialogues = { "", "This is it now..... Dukie...", "I appreciate all your hard work. You really are a hero.", "Its time to bring your evidence back to the case file", "If you need to go back and review the evidence, do so now.", "I'll miss you Dukie, this has been fun.", "May your legacy live on.", "Good luck Detective!!" };

    // Start is called before the first frame update
    void Start()
    {
        LockedBook.SetActive(true); 
        TalkPanel.SetActive(false);
        Camera.SetActive(false);
        PlayerCapsule.SetActive(true);
    }

    // Update is called once per frame
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
            Debug.Log("Displaying dialogue: " + dialogues[i]); // Debug log to check the displayed dialogue
            TalkText.text = dialogues[i];
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E)); // Wait for the player to press E before displaying the next dialogue
            yield return null; // Ensure we only proceed after the E key is released
        }

        EndDialogue();
    }


    void EndDialogue()
    {
        TalkPanel.SetActive(false);
        Camera.SetActive(false);
        PlayerCapsule.SetActive(true);
        LockedBook.SetActive(false);
    }

    void StartDialogue()
    {
        TalkPanel.SetActive(true);
        Camera.SetActive(true);
        PlayerCapsule.SetActive(false);
        LockedBook.SetActive(true);
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

