﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilhouetteControllerScript : MonoBehaviour {
    public float maxSpeed = 10;
    bool facingRight = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float move = Input.GetAxis("horizontal");
        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x += -1;
        transform.localScale = theScale;
    }
}
