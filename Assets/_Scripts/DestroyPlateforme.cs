using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlateforme : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroy")
        {
            // Détruire la plateforme
            Destroy(this.gameObject);
        }
    }
}
