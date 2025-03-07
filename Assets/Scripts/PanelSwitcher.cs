using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject panel1; // Первая панель
    public GameObject panel2; // Вторая панель

    // Метод для показа нужной панели и скрытия другой
    public void ShowPanel(GameObject activePanel)
    {
        panel1.SetActive(activePanel == panel1);
        panel2.SetActive(activePanel == panel2);
    }
}
