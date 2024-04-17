using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI playerScoreText;
    private int currentScore = 0;

    // Méthode pour incrémenter le score
    public void IncrementScore()
    {
        currentScore++;
        UpdateScoreText();
    }

    // Méthode pour mettre à jour le texte du score
    void UpdateScoreText()
    {
        if (playerScoreText != null)
        {
            playerScoreText.text = "Score : " + currentScore.ToString();
        }
    }
}
