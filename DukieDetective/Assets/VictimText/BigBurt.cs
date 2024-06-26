using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class BigBurt : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger;
    private bool isInsideTrigger;
    public GameObject TalkPanel, PlayerCapsule, Camera;
    public TMP_Text TalkText;
    private string[] dialogues = { "", "A murderer you say?", "Yeah I think I seen him.", "But all I remember is that he didn't have a bowl cut.", "Good luck finding him."};

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
