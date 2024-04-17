using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public AudioClip pointSound;
    private AudioSource audioSource;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // Trouve le GameManager dans la scène
        if (gameManager == null)
        {
            Debug.LogError("Veuillez ajouter un objet avec le script GameManager dans la scène.");
        }
        // Récupère le composant AudioSource attaché à ce GameObject
        audioSource = GetComponent<AudioSource>();

        // Vérifie si un AudioSource est attaché, sinon en ajoute un
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Attribue le clip audio au AudioSource
        audioSource.clip = pointSound;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si le collider est celui du joueur
        {
            if (pointSound != null)
            {
                // Joue le son
                audioSource.PlayOneShot(pointSound);
            }
            if (gameManager != null)
            {
                gameManager.CollectPiece(); // Appelle la méthode pour collecter la pièce dans le GameManager
                Destroy(gameObject); // Détruit la pièce après collecte
            }
        }
    }
}
