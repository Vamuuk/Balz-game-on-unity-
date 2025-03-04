using UnityEngine;

public class LoseZone : MonoBehaviour
{
    public CameraFollow cameraFollow; // Ссылка на скрипт камеры
    public Rigidbody ballRigidbody; // Физика мяча
    public GameObject losePanel; // Панель поражения

    private void Start()
    {
        if (losePanel != null)
        {
            losePanel.SetActive(false); // Отключаем панель в начале
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Если мяч коснулся триггера
        {
            cameraFollow.enabled = false; // Остановить камеру
            ballRigidbody.useGravity = true; // Оставить мяч падать
            if (losePanel != null)
            {
                losePanel.SetActive(true); // Включить панель поражения
            }
        }
    }
}
