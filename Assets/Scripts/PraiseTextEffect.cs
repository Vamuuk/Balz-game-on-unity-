using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PraiseTextEffect : MonoBehaviour
{
    public Text praiseText;
    public float pulseSpeed = 0.5f;
    public float scaleMultiplier = 1.3f;

    private Vector3 originalScale;

    void Start()
    {
        if (praiseText != null)
        {
            originalScale = praiseText.transform.localScale;
            StartCoroutine(PulseEffect());
        }
    }

    IEnumerator PulseEffect()
    {
        while (true)
        {
            yield return ScaleText(originalScale * scaleMultiplier, pulseSpeed);
            yield return ScaleText(originalScale, pulseSpeed);
        }
    }

    IEnumerator ScaleText(Vector3 targetScale, float duration)
    {
        float time = 0;
        Vector3 startScale = praiseText.transform.localScale;

        while (time < duration)
        {
            praiseText.transform.localScale = Vector3.Lerp(startScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        praiseText.transform.localScale = targetScale;
    }
}
