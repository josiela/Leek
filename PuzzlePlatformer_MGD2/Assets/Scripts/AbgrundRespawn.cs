using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbgrundRespawn : MonoBehaviour {

    //Reference to Spawnpoint
    [SerializeField] Transform spawnPoint;

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Player1"))
        {
            col.transform.position = spawnPoint.position;
        }
    }

}
