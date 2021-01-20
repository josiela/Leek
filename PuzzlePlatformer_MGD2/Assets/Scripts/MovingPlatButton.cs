using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingPlatButton : MonoBehaviour {

    [SerializeField]
    private Text useText;

    private bool active;
    private bool useAllowed;
    private GameObject platform;
    private Vector3 MovingDirection = Vector3.up;
    public AudioSource audioSource;

    private void Start()
    {
        useText.gameObject.SetActive(false);
        active = false;
        useAllowed = false;
        platform = GameObject.Find("MovingPlat");

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals("Acorn"))
        {
            useText.gameObject.SetActive(true);
            useAllowed = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name.Equals("Acorn"))
        {
            useText.gameObject.SetActive(false);
            useAllowed = false;
        }
    }

    IEnumerator MakeActive()
    {
        active = true;
        yield return new WaitForSeconds(7.0f);
        active = false;
    }

    void Update()
    {
        if (useAllowed && Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(MakeActive());

            FindObjectOfType<AudioManager>().Play("Schalter");
        }

        if (active)
        {
            platform.transform.Translate(MovingDirection * Time.smoothDeltaTime * 3);

            if (platform.transform.position.y > 117)
            {
                MovingDirection = Vector3.down;
            }
            else if (platform.transform.position.y < 107.87)
            {
                MovingDirection = Vector3.up;
            }
        }
    }




}
