using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject collectEffect; // ������ ������� �������
    public float jumpHeight = 1.0f;  // ������ �������������
    public float jumpTime = 0.2f;    // ����� ������
    public float destroyDelay = 0.3f; // �������� ����� ���������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollectStar(); // ����������� ����
            StartCoroutine(DestroyWithEffect());
        }
    }

    private System.Collections.IEnumerator DestroyWithEffect()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + Vector3.up * jumpHeight;

        float elapsedTime = 0;

        while (elapsedTime < jumpTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / jumpTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ������� ������ �������
        if (collectEffect != null)
        {
            GameObject effect = Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f); // ������� ������ ����� 1 �������
        }

        yield return new WaitForSeconds(destroyDelay); // ���� ����� ���������

        Destroy(gameObject); // ������� ������
    }
}
                              