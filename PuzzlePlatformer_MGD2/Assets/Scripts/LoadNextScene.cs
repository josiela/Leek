using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour {

    public bool onPanel1 = false;
    public bool onPanel2 = false;

	// Use this for initialization
	void Start () {
        onPanel1 = false;
        onPanel2 = false;
	}
	
	// Update is called once per frame

    //Checkt, ob beide Figuren in der Wand stehen. Wenn ja wird das nächste Level geladen
	void Update () {
        if (onPanel1 == true && onPanel2 == true)
        {
            SceneManager.LoadScene(3);
        }
    }

    //Wenn die Figur die Wand betritt, wird der Action-Bool onPanel1 bzw. onPanel2 auf true gesetzt
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player1")
        {
            onPanel1 = true;
        }
        if (other.tag == "Player2")
        {
            onPanel2 = true;
        }
    }

    //Wenn eine Figur die Wand wieder verlässt, wird der Bool auf false gesetzt
    public void OnTriggerExit(Collider other)
    {
        onPanel1 = false;
        onPanel2 = false;
    }
}
