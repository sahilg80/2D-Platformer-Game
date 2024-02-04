
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private TextMeshProUGUI levelNameText;
    // Start is called before the first frame update

    private void Start()
    {
        gamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        levelNameText.SetText(scene.name);
        SetScoreInUI(0);
    }

    // Update is called once per frame
    public void SetScoreInUI(int score)
    {
        scoreText.SetText("Score : " + score.ToString());
    }

    public void ShowGameoverPanel()
    {
        Invoke("GameOverUI", 1.4f);
    }

    private void GameOverUI()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        //Time.timeScale = 0f;
    }
}
