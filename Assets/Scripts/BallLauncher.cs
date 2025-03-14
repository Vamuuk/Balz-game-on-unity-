using UnityEngine;

public class BallDrag : MonoBehaviour
{
    private Rigidbody rb;
    private bool isDragging = false;
    private Vector3 startMousePos;
    private Vector3 startBallPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        isDragging = true;
        startMousePos = Input.mousePosition;
        startBallPos = transform.position;
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 currentMousePos = Input.mousePosition;
        Vector3 offset = (currentMousePos - startMousePos) * 0.01f; // ���������������� ���������
        transform.position = startBallPos - offset;
    }

    void OnMouseUp()
    {
        if (!isDragging) return;

        isDragging = false;
        Vector3 launchDirection = (startBallPos - transform.position).normalized;
        float force = Vector3.Distance(startBallPos, transform.position) * 10f; // ���� ������� �� ���������

        rb.linearVelocity = launchDirection * force;
    }
}
