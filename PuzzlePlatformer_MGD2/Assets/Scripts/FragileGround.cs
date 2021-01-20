using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragileGround : MonoBehaviour {

    [SerializeField]
    private Text useText;
    
    private bool landed;
    private bool textVisible;
    private int textcounter;

    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        landed = false;
        textVisible = false;
        textcounter = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (landed == true)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(582.7f, 122.4f, -168.3f);
            cube.transform.localScale = new Vector3(4, 4, 4);
            cube.AddComponent<Rigidbody>();
            cube.GetComponent<Rigidbody>().useGravity = true;
            cube.tag = "Ground";

            GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube2.transform.position = new Vector3(582.7f, 122.4f, -162.3f);
            cube2.transform.localScale = new Vector3(2, 2, 2);
            cube2.AddComponent<Rigidbody>();
            cube2.GetComponent<Rigidbody>().useGravity = true;
            cube2.tag = "Ground";

            GameObject cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube3.transform.position = new Vector3(582.7f, 122.4f, -157.4f);
            cube3.transform.localScale = new Vector3(3f, 3f, 3f);
            cube3.AddComponent<Rigidbody>();
            cube3.GetComponent<Rigidbody>().useGravity = true;
            cube3.tag = "Ground";

            landed = false;
        }

        if (textcounter == 1)
        {
            textVisible = true;
        } else
        {
            textVisible = false;
        }

        if (textVisible)
        {
            useText.gameObject.SetActive(true);
        } else
        {
            useText.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals("Onion"))
        {
            useText.gameObject.SetActive(true);
            landed = true;
            textcounter++;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name.Equals("Onion"))
        {
            useText.gameObject.SetActive(false);
        }
    }
}
