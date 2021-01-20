using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSwitch : MonoBehaviour {

    private GameObject plat1;
    private GameObject plat2;
    private GameObject plat3;
    private GameObject plat4;
    private GameObject plat5;

    private int switchState = 0;
    private bool useAllowed;

    public AudioSource audioSource;

    private void Start()
    {
        plat1 = GameObject.Find("planplat1");
        plat2 = GameObject.Find("planplat2");
        plat3 = GameObject.Find("planplat3");
        plat4 = GameObject.Find("planplat4");
        plat5 = GameObject.Find("planplat5");

        SetInvisible();

        useAllowed = false;
}

    public void SetInvisible()
    {
        plat1.SetActive(false);
        plat2.SetActive(false);
        plat3.SetActive(false);
        plat4.SetActive(false);
        plat5.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Acorn"))
        {
            useAllowed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Acorn"))
        {
            useAllowed = false;
        }
    }

    private void Update()
    {
        if (useAllowed && Input.GetKeyDown(KeyCode.M))
        {
            FindObjectOfType<AudioManager>().Play("Schalter");
            switchState += 1;
            if (switchState > 5)
            {
                switchState = 1;
            }

            switch (switchState)
            {
                case 1:
                    SetInvisible();
                    plat1.SetActive(true);
                    break;
                case 2:
                    SetInvisible();
                    plat2.SetActive(true);
                    break;
                case 3:
                    SetInvisible();
                    plat3.SetActive(true);
                    break;
                case 4:
                    SetInvisible();
                    plat4.SetActive(true);
                    break;
                case 5:
                    SetInvisible();
                    plat5.SetActive(true);
                    break;
                default:
                    SetInvisible();
                    break;
            }
        }
    }
}
