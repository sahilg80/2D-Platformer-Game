
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private GameObject gameOverPanel;
    // Start is called before the first frame update
    
    private void Start()
    {
        gamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
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
    }
}
