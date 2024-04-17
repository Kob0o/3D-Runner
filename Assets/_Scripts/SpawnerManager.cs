using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] plateformes; // Tableau de GameObjects pour stocker les différentes plateformes

    // Méthode pour récupérer une plateforme aléatoire dans le tableau
    public GameObject GetRandomPlateforme()
    {
        if (plateformes.Length == 0)
        {
            Debug.LogError("Aucune plateforme n'est assignée dans le tableau.");
            return null;
        }
        int randomIndex = Random.Range(0, plateformes.Length);
        return plateformes[randomIndex];
    }
}
