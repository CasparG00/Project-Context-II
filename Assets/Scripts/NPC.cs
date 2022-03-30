using TMPro;
using UnityEngine;
using Yarn.Unity;

public class NPC : MonoBehaviour
{
    [Header("Required NPC Data")]
    public string speakerName;
    [Tooltip("The dialogue of this NPC will break if this is not set correctly.")]
    [SerializeField] private string conversationStartNode;
    private DialogueRunner dialogueRunner;
    
    [Header("Optional Dialogue Aesthetics")]
    public Sprite dialogueSprite;
    public Sprite backgroundSprite;
    public TMP_FontAsset font;
    public Color textColor = Color.white;

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
