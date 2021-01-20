using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour {

    public GameObject pf1;
    public GameObject pf2;
    public AudioSource audioSource;

    private bool useAllowed;

    private void Start()
    {
        useAllowed = false;
        pf1.SetActive(false);
        pf2.SetActive(true);

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (useAllowed == true && Input.GetKeyDown(KeyCode.E))
        {
            //pf1.SetActive(false);
            pf2.SetActive(true);
            /*-*/StartCoroutine(Pf1active());

            FindObjectOfType<AudioManager>().Play("Schalter");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player2"))
        {
            useAllowed = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player2"))
        {
            useAllowed = false;
        }
    }

    /*-*/IEnumerator Pf1active()
    {
        yield return new WaitForSeconds(0.1f);
        pf1.SetActive(false);
    }

}
