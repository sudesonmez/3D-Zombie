using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerBar : MonoBehaviour
{
    public Slider timeSlider;
    public GameObject gameOverText;
    public TextMeshProUGUI timeText;
    public Button retryButton;    // Yeniden oyna butonu
    public Button startButton;    // Oyuna başla butonu (yeni)

    private TextMeshProUGUI GameOverTextComponent;
    private float duration = 150f;
    private float timer;
    private bool gameEnded = false;

    void Start()
    {
        timer = duration;

        // Başlangıçta oyun zamanı durdurulur
        Time.timeScale = 0f;

        // UI elemanları başlangıç ayarları
        gameOverText.SetActive(false);
        retryButton.gameObject.SetActive(false);
        retryButton.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
        retryButton.onClick.AddListener(RestartGame);

        startButton.gameObject.SetActive(true);
        startButton.onClick.AddListener(StartGame);

        GameOverTextComponent = gameOverText.GetComponent<TextMeshProUGUI>();
        timeSlider.maxValue = duration;
        timeSlider.value = duration;

        UpdateTimerText();
    }

    void Update()
    {
        if (gameEnded) return;

        if (Time.timeScale == 0f) return; // Oyun başlamadıysa sayaç ilerlemez

        timer -= Time.deltaTime;
        timer = Mathf.Max(timer, 0f);
        timeSlider.value = timer;
        UpdateTimerText();

        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            GameOver(true);
        }
        else if (timer <= 0)
        {
            GameOver(false);
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver(bool won)
    {
        if (gameEnded) return;

        gameEnded = true;
        gameOverText.SetActive(true);
        retryButton.gameObject.SetActive(true);

        if (won)
        {
            GameOverTextComponent.text = "Game Over - Kazandın!";
            GameOverTextComponent.color = Color.green;
        }
        else
        {
            GameOverTextComponent.text = "Game Over - Kaybettin!";
            GameOverTextComponent.color = Color.red;
        }

        Time.timeScale = 0f; // Oyunu durdur
    }

    void RestartGame()
    {
        Time.timeScale = 1f; // Zamanı yeniden başlat
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Sahneyi yeniden yükle
    }

    void StartGame()
    {
        Time.timeScale = 1f; // Oyunu başlat
        startButton.gameObject.SetActive(false); // Başla butonunu gizle
    }
}
