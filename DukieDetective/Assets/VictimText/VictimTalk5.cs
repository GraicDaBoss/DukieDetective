using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class VictimTalk5 : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger;
    private bool isInsideTrigger;
    public GameObject TalkPanel, PlayerCapsule, Camera;
    public TMP_Text TalkText;
    private string[] dialogues = { "", "Good job on reviewing those sketches", "Hope all this work pays off", "In this last chapter, you'll speak to the very suspects and hear their alibis", "Take notes on the details. What adds up, what doesn't?", "", "This is the final stretch now, so keep all previous clues in mind.", "Good luck Hero!!." };

    // Start is called before the first frame update
    void Start()
    {
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

