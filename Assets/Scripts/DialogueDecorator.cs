using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueDecorator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speakerNameProvider;
    [SerializeField] private float fadeSpeed = 10;
    
    [SerializeField] private TextMeshProUGUI[] influencedTextComponents;
    [SerializeField] private Image backgroundImageComponent;
    private Image uiImage;
    private DialogueRunner dialogueRunner;

    private Color targetColor;
    private Color baseBackgroundImageColor;

    private void Start()
    {
        uiImage = GetComponent<Image>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        baseBackgroundImageColor = backgroundImageComponent.color;
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
                    
                    SetStyleOnTextComponents(influencedTextComponents, npc.font, npc.textColor);
                    
                    if (npc.backgroundSprite)
                    {
                        backgroundImageComponent.sprite = npc.backgroundSprite;
                        backgroundImageComponent.color = Color.white;
                    }
                    else
                    {
                        backgroundImageComponent.color = baseBackgroundImageColor;
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

    private void SetStyleOnTextComponents(TextMeshProUGUI[] textComponents, TMP_FontAsset font, Color textColor)
    {
        if (!font) return;
        foreach (var component in textComponents)
        {
            component.font = font;
            component.color = textColor;
        }
    }
}
