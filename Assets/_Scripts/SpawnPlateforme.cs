using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPlateforme : MonoBehaviour
{
    public int offset;
    public GameObject player;
    private SpawnerManager spawnerManager;

    void Start()
    {
        spawnerManager = GameObject.Find("SpawnerManager").GetComponent<SpawnerManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject plateforme = spawnerManager.GetRandomPlateforme(); // Récupérer une plateforme aléatoire

            if (plateforme != null)
            {
                GameObject newPlateforme = Instantiate(plateforme, new Vector3(0, 0, this.transform.position.z + offset), Quaternion.identity);
            }
        }
    }
}
