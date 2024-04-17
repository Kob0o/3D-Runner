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
        gameManager = FindObjectOfType<GameManager>(); // Trouve le GameManager dans la sc�ne
        if (gameManager == null)
        {
            Debug.LogError("Veuillez ajouter un objet avec le script GameManager dans la sc�ne.");
        }
        // R�cup�re le composant AudioSource attach� � ce GameObject
        audioSource = GetComponent<AudioSource>();

        // V�rifie si un AudioSource est attach�, sinon en ajoute un
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Attribue le clip audio au AudioSource
        audioSource.clip = pointSound;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // V�rifie si le collider est celui du joueur
        {
            if (pointSound != null)
            {
                // Joue le son
                audioSource.PlayOneShot(pointSound);
            }
            if (gameManager != null)
            {
                gameManager.CollectPiece(); // Appelle la m�thode pour collecter la pi�ce dans le GameManager
                Destroy(gameObject); // D�truit la pi�ce apr�s collecte
            }
        }
    }
}
