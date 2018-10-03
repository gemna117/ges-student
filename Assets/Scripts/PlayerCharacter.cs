using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCharacter : MonoBehaviour {

    [SerializeField]
    private int lives = 3; //PacalCase or camelCase

    [SerializeField]
    private string name = "Fern";

    private float jumpHeight = 5, speed = 5;

    private bool hasKey;

    private bool isOnGround;

    private Rigidbody2D rigidbody2DInstance;

	// Use this for initialization
	void Start () {

        rigidbody2DInstance = GetComponent<Rigidbody2D>();
        rigidbody2DInstance.gravityScale = 5;
	}
	
	// Update is called once per frame
	private void Update () {

        //transform.Translate(0, -.01f, 0);
        GetInput();
        MoveLeft();
            
	}

    private void GetInput()
    {
        float horizontalInput = Input.GetAxis("horizontal");
    }

    private void MoveLeft()
    {
        rigidbody2DInstance.velocity = new Vector2(horizontalInput, 0);
    }
}
