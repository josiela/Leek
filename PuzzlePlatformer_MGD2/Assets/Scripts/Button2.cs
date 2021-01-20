using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour {

    
    public GameObject pf1;
    public GameObject pf2;
    public AudioSource audioSource;

    private bool useAllowed;

    private void Start()
    {
        useAllowed = false;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (useAllowed == true && Input.GetKeyDown(KeyCode.E))
        {
            pf1.SetActive(true);
            pf2.SetActive(false);

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

}
