using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    public Rigidbody rb;
    public AudioSource audioSource;
    public Animator animator;

    public float speed;
    public int forceConst;

    public float jumpHeight;
    public bool isGrounded;
    public bool canJump;
    public float distanceGround2;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        distanceGround2 = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal2 = Input.GetAxis("Horizontal_P2");

        animator.SetFloat("moveHorizontalOnion", moveHorizontal2);

        Vector3 movement = new Vector3(0.0f, 0.0f, moveHorizontal2);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.10F);
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (!Physics.Raycast(transform.position, -Vector3.up, distanceGround2 + 0.1f))
        {
            isGrounded = false;
            canJump = false;
            print("In The Air");

        } else
        {
            isGrounded = true;
            canJump = true;
            print("On Ground");
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded && canJump && rb.velocity.y < 0)
        {
            Vector3 vel = rb.velocity;
            vel.y = 0;
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
            canJump = false;
            FindObjectOfType<AudioManager>().Play("Jump2");
            animator.Play("Jump", -1, 0.0f);
        }

    }

}
