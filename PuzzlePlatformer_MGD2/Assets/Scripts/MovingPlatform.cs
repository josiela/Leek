using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    private Vector3 MovingDirection = Vector3.up;

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        gameObject.transform.Translate(MovingDirection * Time.smoothDeltaTime * 3);

        if (gameObject.transform.position.y > 117)
        {
            MovingDirection = Vector3.down;
        }
        else if (gameObject.transform.position.y < 107.87)
        {
            MovingDirection = Vector3.up;
        }
    }

    
}