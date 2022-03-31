using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueDecorator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speakerNameProvider;
    [Tooltip("Hands off!")]
    [SerializeField] private Image uiImage;
    [SerializeField] private float fadeSpeed = 10;
    
    [SerializeField] private TextMeshProUGUI[] influencedTextComponents;
    [Tooltip("Don't change this or it will break :(")]
    [SerializeField] private Image backgroundImageComponent;
    private DialogueRunner dialogueRunner;
    
    [Header("Player Style Settings")]
    [SerializeField] private TMP_FontAsset playerFont;
    [SerializeField] private Color playerTextColor;
    [SerializeField] private Color playerBackgroundColor;
    [SerializeField] private int playerFontSize;

    private Color targetColor;

    private void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    private void LateUpdate()
    {
        if (Mathf.Abs(targetColor.a - uiImage.color.a) > 0.05f)
        {
            uiImage.color = Color.Lerp(uiImage.color, targetColor, Time.deltaTime * fadeSpeed);
        }
        else
        {
            uiImage.color = targetColor;
        }
    }
    
    private void FixedUpdate()
    {
        if (dialogueRunner.IsDialogueRunning)
        {
            if (speakerNameProvider.text == "Player")
            {
                targetColor = new Color(1, 1, 1, 0);
                backgroundImageComponent.color = playerBackgroundColor;
                SetStyleOnTextComponents(influencedTextComponents, playerFont, playerTextColor, playerFontSize);
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
                    
                    SetStyleOnTextComponents(influencedTextComponents, npc.font, npc.textColor, npc.fontSize);
                    
                    backgroundImageComponent.color = npc.backgroundColor;
                    break;
                }
            }
        }
        else
        {
            targetColor = new Color(1, 1, 1, 0);
        }
    }

    private void SetStyleOnTextComponents(TextMeshProUGUI[] textComponents, TMP_FontAsset font, Color textColor, int fontSize)
    {
        if (!font) return;
        foreach (var component in textComponents)
        {
            component.font = font;
            component.color = textColor;
            component.fontSize = fontSize;
        }
    }
}
