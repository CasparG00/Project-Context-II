using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class FadeCameraCommand : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 1;
    private Image image;
    private bool isFading;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.color = new Color(0, 0, 0, 0);
    }

    [YarnCommand("FadeCamera")]
    public void FadeCamera(bool fadeIn)
    {
        if (isFading) return;
        StartCoroutine(LerpColor(fadeIn ? new Color(0,0,0,0) : Color.black, fadeSpeed));
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
