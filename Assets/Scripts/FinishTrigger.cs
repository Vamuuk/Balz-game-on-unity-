using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.ShowFinishPanel();

            // ������������� ���, �� �� ��� ����
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero; // �������� ��������
                rb.angularVelocity = Vector3.zero; // ������������� ��������
                rb.isKinematic = true; // ��������� ���
            }
        }
    }
}
