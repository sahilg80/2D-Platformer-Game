
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        SetScoreInUI(0);
    }

    // Update is called once per frame
    public void SetScoreInUI(int score)
    {
        scoreText.SetText("Score : " + score.ToString());
    }
}
