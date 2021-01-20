using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlat1 : MonoBehaviour {

    private bool playerEntered;
    private Vector3 MovingDirection = Vector3.up;
    private bool active;
    private GameObject platform;
    private GameObject trigger;

    private void Start()
    {
        playerEntered = false;
        active = false;
        platform = GameObject.Find("Platform2_top");
        trigger = GameObject.Find("pl2_top_trigger");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals("Onion"))
        {
            StartCoroutine(Entered());
        }
    }

    IEnumerator Entered()
    {
        playerEntered = true;
        yield return new WaitForSeconds(3.9f);
        playerEntered = false;
    }

    IEnumerator MakeActive()
    {
        active = true;
        yield return new WaitForSeconds(3.9f);
        active = false;
    }

    void Update()
    {trigger.transform.Translate(MovingDirection * Time.smoothDeltaTime);

            if (platform.transform.position.y > 129.26)
            {
                MovingDirection = Vector3.down;
            }
            else if (platform.transform.position.y < 123.7)
            {
                MovingDirection = Vector3.up;
            }
        if (playerEntered)
        {
            StartCoroutine(MakeActive());
        }

        if (active)
        {
            platform.transform.Translate(MovingDirection * Time.smoothDeltaTime);
            
        }
    }
}
