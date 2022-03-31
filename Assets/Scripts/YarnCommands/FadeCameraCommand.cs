using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class FadeCameraCommand : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 1;
    [SerializeField] private Color baseColor;
    [SerializeField] private Color sameButTransparent;
    private Image image;
    private bool isFading;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.color = baseColor;
    }

    [YarnCommand("FadeCamera")]
    public void FadeCamera(bool fadeIn)
    {
        if (isFading) return;
        StartCoroutine(LerpColor(fadeIn ? sameButTransparent : baseColor, fadeSpeed));
    }
    
    private IEnumerator LerpColor(Color endValue, float duration)
    {
        isFading = true;
        float time = 0;
        var startValue = image.color;
        while (time < duration)
        {
            image.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        image.color = endValue;
        isFading = false;
    }
}
