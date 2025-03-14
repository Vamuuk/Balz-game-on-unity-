using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;  // Главное меню
    public GameObject levelsPanel;    // Панель выбора уровней
    public GameObject settingsPanel;  // Панель настроек

    public void OpenLevels()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (levelsPanel != null) levelsPanel.SetActive(true);
    }

    public void OpenSettings()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
