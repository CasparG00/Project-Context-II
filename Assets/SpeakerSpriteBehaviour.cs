using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class SpeakerSpriteBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speakerNameProvider;
    [SerializeField] private float fadeSpeed = 10;
    private Image uiImage;
    private DialogueRunner dialogueRunner;

    private Color targetColor;

    private void Start()
    {
        uiImage = GetComponent<Image>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    private void LateUpdate()
    {
        uiImage.color = Color.Lerp(uiImage.color, targetColor, Time.deltaTime * fadeSpeed);
    }
    
    private void FixedUpdate()
    {
        if (dialogueRunner.IsDialogueRunning)
        {
            if (speakerNameProvider.text == "Player")
            {
                uiImage.color = new Color(1, 1, 1, 0);
            }
            else
            {
                var npcs = FindObjectsOfType<NPC>();
                foreach (var npc in npcs)
                {
                    if (npc.speakerName != speakerNameProvider.text) continue;
                    if (npc.dialogueSprite)
                    {
                        targetColor = new Color(1, 1, 1, 1);
                        uiImage.sprite = npc.dialogueSprite;
                    }
                    else
                    {
                        targetColor = new Color(1, 1, 1, 0);
                    }
                    break;
                }
            }
        }
        else
        {
            targetColor = new Color(1, 1, 1, 0);
        }
    }
}
