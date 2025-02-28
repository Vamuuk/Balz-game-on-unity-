using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Шар
    public float smoothSpeed = 0.1f; // Скорость запаздывания
    public Vector2 offset; // Смещение камеры (настрой в инспекторе)
    public Animator cameraAnimator; // Аниматор камеры
    public BallController playerController; // Скрипт управления игроком

    private bool followPlayer = false; // Флаг, когда начинать следить за игроком

    void Start()
    {
        if (playerController != null)
        {
            playerController.enabled = false; // Отключаем управление игрока
        }

        StartCoroutine(StartCameraAnimation());
    }

    IEnumerator StartCameraAnimation()
    {
        if (cameraAnimator != null)
        {
            cameraAnimator.Play("CameraIntro"); // Запуск анимации
            yield return new WaitForSeconds(cameraAnimator.GetCurrentAnimatorStateInfo(0).length); // Ждем, пока она закончится
            cameraAnimator.enabled = false; // Отключаем аниматор
        }

        followPlayer = true; // Включаем следование за игроком

        if (playerController != null)
        {
            playerController.enabled = true; // Включаем управление игрока
        }
    }

    void LateUpdate()
    {
        if (!followPlayer || target == null) return;

        // Плавное следование за игроком
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
