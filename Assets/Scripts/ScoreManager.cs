using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Текст "Счет: XX%"
    public Text finalScoreText; // Текст на финальной панели
    public GameObject endPanel; // Панель завершения уровня

    private int totalStars; // Сколько всего звезд на уровне
    private int collectedStars = 0; // Сколько собрали

    void Start()
    {
        totalStars = GameObject.FindGameObjectsWithTag("Star").Length; // Подсчет звезд на сцене
        UpdateScore();
        endPanel.SetActive(false); // Прячем панель
    }

    public void CollectStar()
    {
        collectedStars++;
        UpdateScore();
    }

    void UpdateScore()
    {
        float percentage = (collectedStars / (float)totalStars) * 100f;
        scoreText.text = "Score: " + Mathf.RoundToInt(percentage) + "%";
    }

    public void FinishLevel()
    {
        float percentage = (collectedStars / (float)totalStars) * 100f;
        string rank = GetRank(percentage);

        finalScoreText.text = "You scored: " + Mathf.RoundToInt(percentage) + "%\nRank: " + rank;
        endPanel.SetActive(true);
        Time.timeScale = 0; // Остановка игры
    }

    string GetRank(float percentage)
    {
        if (percentage >= 90) return "GOLD ";
        if (percentage >= 60) return "WELL! ";
        return "COOL ";
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
