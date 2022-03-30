using UnityEngine;
using Yarn.Unity;

public class NPC : MonoBehaviour
{
    public string speakerName;
    public Sprite dialogueSprite;
    [SerializeField] private string conversationStartNode;
    private DialogueRunner dialogueRunner;

    private void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }
    
    public void StartConversation()
    {
        if (dialogueRunner.IsDialogueRunning) return;
        dialogueRunner.StartDialogue(conversationStartNode);
    }
}
