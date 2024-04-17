using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collision_Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterMovement cm = other.GetComponent<CharacterMovement>();
            cm.isDead = true;
        }
    }

}
