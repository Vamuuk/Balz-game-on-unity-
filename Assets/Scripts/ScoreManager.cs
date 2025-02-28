using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // ����� "����: XX%"
    public Text finalScoreText; // ����� �� ��������� ������
    public GameObject endPanel; // ������ ���������� ������

    private int totalStars; // ������� ����� ����� �� ������
    private int collectedStars = 0; // ������� �������

    void Start()
    {
        totalStars = GameObject.FindGameObjectsWithTag("Star").Length; // ������� ����� �� �����
        UpdateScore();
        endPanel.SetActive(false); // ������ ������
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
        Time.timeScale = 0; // ��������� ����
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
