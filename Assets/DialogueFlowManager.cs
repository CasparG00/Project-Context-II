using UnityEngine;
using Yarn.Unity;

public class DialogueFlowManager : MonoBehaviour
{
    private DialogueRunner dialogueRunner;

    private void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    private void Update()
    {
        dialogueRunner.VariableStorage.TryGetValue("$talkedToSecretary", out bool talkedToSecretary);
    }
}
