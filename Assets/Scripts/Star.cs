using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject collectEffect; // Префаб эффекта вспышки
    public float jumpHeight = 1.0f;  // Высота подпрыгивания
    public float jumpTime = 0.2f;    // Время прыжка
    public float destroyDelay = 0.3f; // Задержка перед удалением

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollectStar(); // Увеличиваем счет
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

        // Создаем эффект вспышки
        if (collectEffect != null)
        {
            GameObject effect = Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f); // Удаляем эффект через 1 секунду
        }

        yield return new WaitForSeconds(destroyDelay); // Ждем перед удалением

        Destroy(gameObject); // Удаляем звезду
    }
}
                              