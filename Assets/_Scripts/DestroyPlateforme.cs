using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlateforme : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroy")
        {
            // D�truire la plateforme
            Destroy(this.gameObject);
        }
    }
}
