using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI startText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI scoreText;
    public void ShowStartText()
    {
        startText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(false);
    }

    public void HideAll()
    {
        startText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);
    }

    public void ShowRestartText()
    {
        
        startText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
