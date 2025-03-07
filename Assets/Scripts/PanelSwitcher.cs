using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject panel1; // ������ ������
    public GameObject panel2; // ������ ������

    // ����� ��� ������ ������ ������ � ������� ������
    public void ShowPanel(GameObject activePanel)
    {
        panel1.SetActive(activePanel == panel1);
        panel2.SetActive(activePanel == panel2);
    }
}
