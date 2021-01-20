using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour {

    // implementiert die Klasse "explosion", die auf der exploding_door liegt
    //public explosion explodingWall;

    [SerializeField]
    private Text useText;
    private GameObject wall;

    private bool useAllowed;
    private bool notUsable;

    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
       useText.gameObject.SetActive(false);
        // Das Objekt "Door" wird gefunden und kann unter dem Namen "Wall" benutzt werden
        wall = GameObject.Find("Door");
        useAllowed = false;
        notUsable = false;

        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (useAllowed && notUsable==false && Input.GetKeyDown(KeyCode.E))
        {
            DestroyGameObject();
            useAllowed = false;

           // FindObjectOfType<AudioManager>().Play("Schalter");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals("Onion"))
        {
            useText.gameObject.SetActive(true);
            useAllowed = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name.Equals("Onion"))
        {
            useText.gameObject.SetActive(false);
            useAllowed = false;
        }
    }

    private void DestroyGameObject()
    {
        Destroy(wall);
        useText.gameObject.SetActive(false);
        //nutzt die Funktion doit --> also explode aus der Klasse explosion
        //explodingWall.Explode();
        notUsable = true;
        FindObjectOfType<AudioManager>().Play("Explosion");
    }
}
