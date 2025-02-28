using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalStars;
    private int collectedStars = 0;
    public Text scoreText; // Отображение счета (правый верхний угол)
    public Text scoreTextFinal; // Отображение счета в конце матча

    public GameObject finishPanel;
    public GameObject gameUI;
    public Text praiseText;
    public Button restartButton;
    public Button nextLevelButton;

    public GameObject[] stars;
    public Rigidbody ballRigidbody;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        collectedStars = 0;
        UpdateScore();
        finishPanel.SetActive(false);
        gameUI.SetActive(false);

        StartCoroutine(ShowGameUIAfterDelay(4f));

        foreach (GameObject star in stars)
        {
            star.SetActive(false);
        }

        if (restartButton != null)
            restartButton.onClick.AddListener(RestartLevel);

        if (nextLevelButton != null)
            nextLevelButton.onClick.AddListener(NextLevel);
    }

    private IEnumerator ShowGameUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameUI.SetActive(true);
    }

    public void CollectStar()
    {
        collectedStars++;
        UpdateScore();
    }

    private void UpdateScore()
    {
        int score = collectedStars * 100;
        scoreText.text = "Score: " + score;
    }

    public void ShowFinishPanel()
    {
        finishPanel.SetActive(true);
        finishPanel.transform.localScale = Vector3.zero;
        StartCoroutine(AnimatePanel(finishPanel, Vector3.one, 0.5f));

        gameUI.SetActive(false);

        if (ballRigidbody != null)
        {
            ballRigidbody.linearVelocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
            ballRigidbody.constraints = RigidbodyConstraints.FreezePosition;
        }

        float percentage = (totalStars > 0) ? ((float)collectedStars / totalStars) * 100f : 0;
        UpdateStars(percentage);
        scoreTextFinal.text = " " + (collectedStars * 100);
        praiseText.text = GetPraise(percentage);
    }

    private void UpdateStars(float percentage)
    {
        if (percentage >= 30) StartCoroutine(ShowStar(stars[0]));
        if (percentage >= 60) StartCoroutine(ShowStar(stars[1]));
        if (percentage >= 90) StartCoroutine(ShowStar(stars[2]));
    }

    private IEnumerator ShowStar(GameObject star)
    {
        if (!star.activeSelf)
        {
            star.SetActive(true);
            star.transform.localScale = Vector3.zero;

            float elapsedTime = 0f;
            float duration = 0.5f;

            while (elapsedTime < duration)
            {
                star.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            star.transform.localScale = Vector3.one;
        }
    }

    private IEnumerator AnimatePanel(GameObject panel, Vector3 targetScale, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startScale = Vector3.zero;

        while (elapsedTime < duration)
        {
            panel.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panel.transform.localScale = targetScale;
    }

    private string GetPraise(float percentage)
    {
        if (percentage >= 90) return "SUPERHERO!";
        if (percentage >= 60) return "WELL DONE!";
        return "COOL!";
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        if (ballRigidbody != null)
            ballRigidbody.constraints = RigidbodyConstraints.None;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        if (ballRigidbody != null)
            ballRigidbody.constraints = RigidbodyConstraints.None;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
