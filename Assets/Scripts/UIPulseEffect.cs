using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPulseEffect : MonoBehaviour
{
    [SerializeField] private float minScale = 0.9f; // ����������� ������
    [SerializeField] private float maxScale = 1.1f; // ������������ ������
    [SerializeField] private float speed = 1.5f;    // �������� ���������

    private Vector3 originalScale;
    private bool isPulsing = false;

    void Awake()
    {
        originalScale = transform.localScale;
    }

    void OnEnable()
    {
        StartCoroutine(StartPulseWithDelay());
    }

    IEnumerator StartPulseWithDelay()
    {
        yield return null; // ��� ���� ����, ����� Unity ������� ������
        isPulsing = true;
    }

    void Update()
    {
        if (isPulsing)
        {
            float scaleFactor = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(Time.time * speed) + 1) / 2);
            transform.localScale = originalScale * scaleFactor;
        }
    }

    public void StartPulse()
    {
        isPulsing = true;
    }

    public void StopPulse()
    {
        isPulsing = false;
        transform.localScale = originalScale; // ������� ������������ ������
    }
}
