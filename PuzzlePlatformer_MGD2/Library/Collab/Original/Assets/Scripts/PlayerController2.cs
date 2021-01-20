
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    public Rigidbody rb;
    public AudioSource audioSource;

    public float speed;
    public int forceConst;

    public float jumpHeight;
    public bool isGrounded;
    public bool canJump;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal_P2");
        float moveVertical = Input.GetAxis("Vertical_P2");

        Vector3 movement = new Vector3(0.0f, 0.0f, moveHorizontal);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.W) && isGrounded && canJump)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
            canJump = false;
            //Jumpsound
            FindObjectOfType<AudioManager>().Play("Jump2");
        }

    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground" && isGrounded == false)
        {
            isGrounded = true;
            canJump = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground" && isGrounded == true)
        {
            isGrounded = false;
            canJump = false;
        }
    }

}
