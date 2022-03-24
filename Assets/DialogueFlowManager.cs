using UnityEngine;
using Yarn.Unity;

public class DialogueFlowManager : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    private bool talkedToSecretary;

    private void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    private void Update()
    {
        dialogueRunner.VariableStorage.TryGetValue("$talkedToSecretary", out talkedToSecretary);
    }
}
