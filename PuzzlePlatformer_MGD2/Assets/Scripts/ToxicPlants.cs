using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicPlants : MonoBehaviour
{

    //Reference to Spawnpoint
    [SerializeField] Transform spawnPoint3;

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Player2"))
        {
            col.transform.position = spawnPoint3.position;
        }
    }
}
