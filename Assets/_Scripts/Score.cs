using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI playerScoreText;
    private int currentScore = 0;

    // M�thode pour incr�menter le score
    public void IncrementScore()
    {
        currentScore++;
        UpdateScoreText();
    }

    // M�thode pour mettre � jour le texte du score
    void UpdateScoreText()
    {
        if (playerScoreText != null)
        {
            playerScoreText.text = "Score : " + currentScore.ToString();
        }
    }
}
