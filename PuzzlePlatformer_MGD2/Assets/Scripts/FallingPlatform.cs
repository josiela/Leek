using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    [SerializeField] Transform spawnPoint;
    private GameObject platform;
    private bool boolSetBack;

    private bool boolActive;
    private bool active;
    private bool setBack;
    private Vector3 MovingDirection = Vector3.up;

    void Start()
    {
        boolActive = false;
        boolSetBack = false;
        setBack = false;
        platform = GameObject.Find("Platform2_top");
        active = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Onion"))
        {
            boolActive = true;
        }
    }

    IEnumerator Gravity()
    {
        yield return new WaitForSeconds(1.5f);
        active = true;
        yield return new WaitForSeconds(5.0f);
        platform.transform.position = spawnPoint.position;
    }

    private void Update()
    {
        if (boolActive)
        {
            StartCoroutine(Gravity());
            boolActive = false;
        }

        if (active)
        {
            platform.transform.Translate(MovingDirection * Time.smoothDeltaTime * 3);

            if (platform.transform.position.y > 130.3)
            {
                MovingDirection = Vector3.down;
            }
            else if (platform.transform.position.y < 124.8)
            {
                active = false;
            }
        }
    }


}