using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {


    public float fallMultiplier = 2.5f;
    // when Jumpbutton is released and more gravity is applied, Player shall not be able to jump as high as earlier:
    public float lowJumpMultiplier = 2f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // vertical motion less then zero (falling):
        if(rb.velocity.y < 0)
        {
            // apply our fallmultiplier to our gravity
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

}
