using UnityEngine;
using Yarn.Unity;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LineView lineView;
    private DialogueRunner dialogueRunner;

    private bool canInteract;
    private NPC interactibleObject;

    private void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    private void Update()
    {
        if (!canInteract) return;
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!dialogueRunner.IsDialogueRunning)
            {
                if (interactibleObject != null)
                {
                    interactibleObject.StartConversation();
                }
            }
            else
            {
                if (lineView == null) return;
                lineView.UserRequestedViewAdvancement();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canInteract = true;
        interactibleObject = other.GetComponent<NPC>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canInteract = false;
        interactibleObject = null;
    }
}
