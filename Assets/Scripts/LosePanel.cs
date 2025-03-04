using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    public Button restartButton;
    public Button menuButton;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartLevel);
        menuButton.onClick.AddListener(LoadMenu);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
