using UnityEngine;
using Yarn.Unity;

public class NPC : MonoBehaviour
{
    public string speakerName;
    [SerializeField] private Transform dialogueBubbleAnchor;
    [SerializeField] private string[] conversationStartNode;
    private DialogueRunner dialogueRunner;

    private int myIndex;
    private int Index
    {
        get => myIndex;
        set => myIndex = Mathf.Clamp(value, 0, conversationStartNode.Length - 1);
    }

    private void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }
    
    public void StartConversation()
    {
        if (dialogueRunner.IsDialogueRunning) return;
        dialogueRunner.StartDialogue(conversationStartNode[Index]);
    }

    public Transform GetBubbleAnchor()
    {
        Index++;
        return dialogueBubbleAnchor;
    }
}
