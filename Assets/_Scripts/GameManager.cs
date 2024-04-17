using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Score scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<Score>(); // Trouve le gestionnaire de score dans la scène
        if (scoreManager == null)
        {
            Debug.LogError("Veuillez ajouter un objet avec le script Score dans la scène.");
        }
    }

    // Méthode appelée lorsque le joueur ramasse une pièce
    public void CollectPiece()
    {
        if (scoreManager != null)
        {
            scoreManager.IncrementScore(); // Incrémente le score
        }
    }
}
