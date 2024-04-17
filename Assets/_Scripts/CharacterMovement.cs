using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public bool movement = false;
    private float speed = 20.0f;
    public Transform left;
    public Transform right;
    public Transform central;
    public Vector3 target;
    public bool isDead = false;
    public Button restartButton;
    public Image image;
    private CharacterController controller;

    // Variables pour le saut
    public bool isJumping = false;
    public float jumpForce = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float threshold = 0.01f;
        // Déplacement continu vers l'avant
        if (!isDead)
        {
            // Appliquer la gravité
            // Appliquer la gravité uniquement si le personnage n'est pas en train de sauter
            if (!controller.isGrounded)
            {
                controller.Move(Vector3.down * 9.81f * Time.deltaTime);
            }


            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
            if (movement)
            {
                // Fixer la hauteur et la profondeur de la cible
                target = new Vector3(target.x, transform.position.y, transform.position.z);

                // Lerp pour transposer la position actuelle sur la position cible
                transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);

                // Si la position actuelle est proche de la position cible, arrêter le mouvement
                if (Vector3.Distance(transform.position, target) < 0.01f)
                {
                    movement = false;
                }
            }

            // Gestion du saut
            if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
            {
                isJumping = true;
                Vector3 jumpDirection = Vector3.up * jumpForce; // Direction du saut
                controller.Move(jumpDirection * Time.deltaTime);
            }

        }
        else
        {
            restartButton.gameObject.SetActive(true);
            image.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Mathf.Abs(transform.position.x - central.position.x) < threshold)
            {
                target = left.position;
                movement = true;
            }
            else if (Mathf.Abs(transform.position.x - right.position.x) < threshold)
            {
                target = central.position;
                movement = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Mathf.Abs(transform.position.x - central.position.x) < threshold)
            {
                target = right.position;
                movement = true;
            }
            else if (Mathf.Abs(transform.position.x - left.position.x) < threshold)
            {
                target = central.position;
                movement = true;
            }
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
