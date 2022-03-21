using TMPro;
using UnityEngine;
using Yarn.Unity;

public class DialogueBubbleBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBubble;
    [SerializeField] private TextMeshProUGUI speakerNameProvider;

    private DialogueRunner dialogueRunner;
    
    [SerializeField] private Transform playerBubbleAnchor;

    private void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        DisableDialogueBubble();
    }

    private void Update()
    {
        if (!dialogueRunner.IsDialogueRunning) return;

        if (speakerNameProvider.text == "Player")
        {
            dialogueBubble.transform.position = Camera.main.WorldToScreenPoint(playerBubbleAnchor.position);
        }
        else
        {
            var npcs = FindObjectsOfType<NPC>();
            foreach (var npc in npcs)
            {
                if (npc.speakerName == speakerNameProvider.text)
                {
                    dialogueBubble.transform.position = Camera.main.WorldToScreenPoint(npc.GetBubbleAnchor().position);
                    break;
                }
            }
        }
    }

    public void EnableDialogueBubble()
    {
        dialogueBubble.SetActive(true);
    }

    public void DisableDialogueBubble()
    {
        dialogueBubble.SetActive(false);
    }
}
