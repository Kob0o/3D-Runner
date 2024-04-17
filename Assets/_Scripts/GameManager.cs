using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Score scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<Score>(); // Trouve le gestionnaire de score dans la sc�ne
        if (scoreManager == null)
        {
            Debug.LogError("Veuillez ajouter un objet avec le script Score dans la sc�ne.");
        }
    }

    // M�thode appel�e lorsque le joueur ramasse une pi�ce
    public void CollectPiece()
    {
        if (scoreManager != null)
        {
            scoreManager.IncrementScore(); // Incr�mente le score
        }
    }
}
