using System;
using UnityEngine;
using Yarn.Unity;

public class SetSpriteCommand : MonoBehaviour
{
    [SerializeField] private SpriteData[] sprites;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    [YarnCommand("SetSprite")]
    public void SetSprite(string spriteName)
    {
        foreach (var sprite in sprites)
        {
            if (sprite.name != spriteName) continue;
            spriteRenderer.sprite = sprite.sprite;
            return;
        }
    }

    [Serializable]
    public class SpriteData
    {
        public string name;
        public Sprite sprite;
    }
}
